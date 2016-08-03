# Pest Control Classroom Prototype

Classroom - http://gie.prototype1.io/, Admin - http://gie-admin.prototype1.io/0.PCT.Login.html
 
The classroom prototype is where pest control technicians will create accounts, take courses/tests, and receive continuing education credits from their state. You can click through the entire process of creating an account, searching for > selecting > taking a course and test, and send your certificate to your manager or state. There are a few nuances
*  Courses are broken into sections that have questions.

*  A user must finish the entire section before moving onto another section however he doesn’t need to go through the section in order

*  There are 4 types of questions, all of which you’ll see in the example

    * Multiple text choices (options are text only)

    * Multiple images choices (options are images with optional text footer)

    * Single image with multiple text choices (options are text only)

    * Video with text choices (options are text only)

*   In the course – in this prototype, each question will tell you chose the incorrect answer the first time and the second time you select answer it will tell you “You’re right” then allow you to go to the next question (there are only 4). Obviously this is only functionality for the prototype. The course will allow the user to answer as many times as necessary until they get it right.

*   In the course – The document in the course is a pdf the our system will convert to a jpg for simplicity of implementation across browsers. However if the user downloads it, the document will download as a pdf.

*    In the course – The left side has a vertical bar of circles that list the sections for the user to navigate.

*    The test has an odd process – it is taken 1 time straight through, without feedback to the user. If the user doesn’t pass the test he will be prompted to go through the test again but only be required to answer the questions he got wrong (the ones he got right will be shown but the correct options will be selected). If the user still does not pass they are required to go through the answers they still have wrong (but the correct ones no longer shown). The user gets a total of 3 attempts to pass a test.

*    The prototype shows the user failing the first 2 times through and then passing on the 3rd attempt.

*    Once the user has completed the test he can send certificate to his state and managers to prove his completion.

*    The Admin prototype is where the course/tests are created.  You won’t need to worry about this but it may help with context.