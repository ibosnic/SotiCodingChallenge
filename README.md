# Soti Coding Challenge

## Challenge
Given two words of equal length that are in a dictionary, write a method to transform one word 
into another word by changing only one letter at a time. The new word you get in each step must be in the dictionary 
(assume English wordlist). 

EXAMPLE: 

Input: DAMP, LIKE 

Output: DAMP -> LAMP -> LIMP -> LIME -> LIKE

## Implementation
Since you need to get one transformation of the words I used a depth first search approach to 
find a valid transformation, keeping track of all the intermediate results so that 
they can be printed out. For the spell checking of tranformations I used the [NetSpell] library.

[NetSpell]: https://github.com/loresoft/NetSpell 