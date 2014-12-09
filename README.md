Assume that there is a climber who wants to go to place B from place A and there are some mountains between place A and B.

To make the problem simpler, we assume each mountain is a rectangle, which could be reprsented by a 3-tuple (2,4,5). This tuple means that the mountain begins from position 2 and ends at position 4 while its height is 5.

Let's assume place A is at position 0 and all the mountains' positions are non-negative. 

The question is, if the climber starts from place A, climbs up when a mountain is in front of him and climbs down when he meets a cliff, how much does this climber need to walk?

We will input multiple lines. The first line the number of rectangles, then each line is a comma-separated 3-tuple to indicate the position and height of the rectangle.

Input:
3
1,3,2
2,4,4
6,7,5

Output:
25

Input:
3
1,4,1
2,3,3
5,6,2

Output:
16

