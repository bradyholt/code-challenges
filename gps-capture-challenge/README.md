# GPS Capture Challenge

You need to collect a lot of GPS data.

The data payload will have the following fields, and they must be valid:

- Latitude & Longitude
- Elevation
- A timestamp
- Client identification

Additionally, the data payload may contain any other kind of data. It’s not clear right now what it might be, but you will need to collect and retain it for any future use of this data.

Data points can arrive in any order.

The client that produces this data might not be changeable in the future; once it is in the wild, you won’t have much control over it. New clients, however, might implement new versions of the data protocol.

In addition to capturing this data, it will need to be available to other consumers. These consumers might be business analysts or systems administrators within your organization, or third-parties.

Finally, dropping data is not acceptable. If you can’t immediately process a data payload, you’ll need a strategy for managing failures until they can be retried.

## Challenge

Describe in detail how you would design a system to accommodate this data.

- What is a broad overview of the system?
- What are the key technologies in use? Why would you choose them?
- How would you scale the system?
- How would you handle legacy clients?
- What would you do to store the data long-term?
- How would you make data available to other consumers?
