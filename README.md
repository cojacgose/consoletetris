# consoletetris
Trying to build Tetris in C# using nothing but the console - just for practice! Plan on adding rotating blocks at some point!
I'm am doing this without looking up how tetris actually works, only looking up stuff that involves 
I had a rotation function in another solution, but I lost it :( - I guess that's why you should always push to github?

What needs to be done to this:
-Randomized Block Shapes - the classic Tetrominos we all know and love!
-Create a rotation function
  -This will rotate an multidimensional array using a nested loop, moving the data like:
    (With a 4x4) A1->A2 / A2->B2 / B1->A1 / B2->B1 - this will work with any square array, I had this working at one point but lost it ;_;
  -Rotate will also do a check before rotation takes place, checking that all squares that will be rotated into are empty
    -If squares (coordinates on grid) are not empty, then rotation will occur, but the block will be moved up and cause a 'connect' stopping the block movement
    -If the squares that would be rotated into are out of bounds (ie on the sides) then the block will be 'nudged' to the side
    -The checking only occurs for the would-be positions of tetromino's components - not empty parts of the containing array
 -Create a ScoreBoard
 -Change gamespeed dependant on current score
 
 That should give a full Tetris Experience! There of course could be all kinds of fun things to do after the base game is created:
  -Better Display!
  -Pentominoes? Hexominoes? Heptominoes? Randomly generated N-tominoes?
  -Different types of blocks, with bonus score for same-types of blocks in a cleared line!
  
If you're reading this, let me know what you think!
