# Phone Numbers

1. Write a program that can compute the number of unique, valid phone numbers with the following constraints:
 - A valid phone number is seven digits in length
 - A valid phone number cannot begin with a zero or a one
 - A valid phone number can contain only digits
 - A valid phone number must consist of a sequence of digits that can be traced by the movements of a chess piece on a normal telephone keypad

<pre>
1 2 3 
4 5 6 
7 8 9 
* 0 # 
* </pre>

The program should be written so that it could work with any chess piece, but for the purposes of this test you only need to implement for the knight, which has the following valid move pattern for a piece starting at the center dot: 

<pre>
O X 0 X O 
X O O O X
O O O O O
X O O O X
O X 0 X O 
</pre>

For example, a knight starting on the number 8 could move to 1 or 3.  From 1 it could move to 6 or 8, etc.  You are encouraged to write the program in C#, but if you do not feel comfortable enough with the language, you can use C++ instead.

**Additional Instructions**

When you are finished, you will be asked to review the test with another developer.  Our evaluation criterion includes both your approach to the solution as well as your answer to the problem.  You do not need to spend time documenting you code; you can discuss the code as you review it with one of the developers.

The time limit is four hours. You do not get extra credit for finishing quickly, nor are you penalized for taking the full four hours.  We would much rather see a well designed solution than a quick answer to the problem.