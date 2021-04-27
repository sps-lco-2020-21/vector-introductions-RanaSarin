# An introduction to vectors

The syllabus in [section 4.2.8](https://www.aqa.org.uk/subjects/computer-science-and-it/as-and-a-level/computer-science-7516-7517/subject-content-a-level/fundamentals-of-data-structures) introduces what you need to know about vectors. 

The Bond 1 text book (available through your Google Classroom reference materials) pages 300-302 discusses some of the functions. 

For this exercise: 

Create a Vector class and in it write functions that: 
- adds two vectors together
- performs scalar vector multiplication
- calculates the algebraic dot product of two vectors *u* and *v*
- calculates the convex combination of two vectors *u* and *v* of the form **a*u*** + **b*v*** where **a**,**b** >= 0 and **a**+**b** = 1
- calculates the geometric dot product of two vectors *u*  and *v*
- takes two vectors *u*  and *v* and returns the angle between the two vectors (perhaps offer a boolean to specify radians or degrees) 

Make sure you include adequate testing. Your Vector class should be able to instantiate vectors of different classes. 

You might consider creating a bespoke exception to deal with certain situations (e.g. a dot product of vectors of different sizes). 

