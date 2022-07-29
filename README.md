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


Found the code for rotations!!! Here it is with a little break down - not sure if it will make sense to anyone else :D

123
456
789
 
741
852
963
 
3.1 2.1 1.1
3.2 2.2 1.2
3.3 2.3 1.3
 
 
xxx
xxx
xxx
 
list of lists
X.Y
 
rotate{
X2.Y2
for(i=0; i<X.LENGTH;i++){
               
                for(j=X.Y.LENGTH; j>0;j--){
                                k=0;
                                X2[i].Y2[k] = X[j].Y[i];
                                k++;
                               
                }
 
}
X.Y = X2.Y2
}
![image](https://user-images.githubusercontent.com/19919293/181682479-386b2afa-4f4d-4f11-8f78-52d1b1ab59a3.png)
