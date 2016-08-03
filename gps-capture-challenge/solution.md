# GPS Capture Challenge
This design document is in response to the GPS Capture Challenge located here: [https://c1codechallenge.herokuapp.com/challenges/gps-capture.html](https://c1codechallenge.herokuapp.com/challenges/gps-capture.html)

## What is a broad overview of the system?
1. A Rails RESTful API endpoint would handle incoming POST requests containing GPS data.  To accomodate scaling, a NGINX reverse proxy would be setup on the front and configured to forward requests to multiple back-end Rails API endpoints.
2. First pass validation would be handled in the API controller a 200 or 400 status respose would be returned, depending on the validity of the data.
3. The processing and persistance of data would be shuttled off to a queue in RabbitMQ, a message broker.  This will increase throughput and prevent dropped data.  One-to-many Ruby worker apps would subscribe to the queue and process the messages.
4. Persistence would be done using a sharded MongoDB cluster.  This approach allows for schemaless storage of aribrary data points and will scale horizontally.  
5. For data consumption, I would write a Rails web application and/or utilize Elasticsearch Kibana depending upon the comsuption needs.

It should be noted that although this design calls for horizontal scaling components (i.e. reverse proxy in front on web servers, multiple Ruby workers subscribing to message queue, sharfed MonoDB cluster), these aspects of the design would not need to be implemented initially.  However, with this design it should be easy to augment the system to scale as the load increases.

### Design Diagram

![GPS Capture Challenge Design](https://docs.google.com/drawings/d/1zSO3mAJtmi2UULYjMLMxIJeBB9cpdBG9Le2fuWoHK9Q/pub?w=968&h=1162 "GPS Capture Challenge Design")

## What are the key technologies in use? Why would you choose them?
- **Ruby / Rails**
- **MongoDB** - allows storing of arbitrary data and can be setup as a sharded cluster for scalability
- **RabbitMQ** - rock solid message queue broker; allows offloading with fail-retry capability
- **Elasticsearch** - allows fast searching and fetching of data via Kibana
- **Kibana** - rich front-end for visualizing Elasticsearch index documents; trival to setup and very flexibility for consumers
- **NGINX** - fast web server and can be used as a reverse proxy to balance incoming load

## How would you scale the system?
Data would be offloaded for processing and persistence through a RabbitMQ clustered queue.  When messages come in through the load balanced endpoints, they would be asynchronously sent to a queue and then one-to-many Ruby workers would pick messages up off the queue and do the work.  RabbitMQ will allow messages to be handled quickly from the API and support a worker fan-out strategy so that multiple workers can handle requests.  If any failures occur, the messages will not be taken off the queue but handled by another worker.  As load increased more front-end web servers could be added behind the NGINX reverse proxy.

## How would you handle legacy clients?
The API would use a namespaced endpoint.  For example, the initial release would be at an endpoint named "/api/**v1**/gpsdata".  This endpoint is versioned so that new versions can use a modified endpoint (i.e. "/api/**v2**/gpsdata") name while the /v1 endpoint can remain static.   

## What would you do to store the data long-term?
Data would be stored in a shared MongoDB cluster to handle storage and retrival of very large datasets.  If the size of the data becomes unmanageably large over time, it could be archived to AWS S3 and available for offline processing when needed.

## How would you make data available to other consumers?
Depending on the consumer needs, I would either write a Rails web app or index the data in Elasticsearch and leverage Kibana with BetterMap (http://www.elasticsearch.org/blog/enriching-searches-open-geo-data/) to visualize the data.  Kibana is easy to setup by pointing it to an Elasticsearch index and configuring the visualization.  Additionally, if some consumers are systems, a GET endpoint could be provided on the front web servers to pull data over the RESTful API.
