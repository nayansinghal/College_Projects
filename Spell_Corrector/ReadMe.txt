Spell Corrector

1. Given a word, it chooses the most likely correct spelling for that word.
2. To accomplish the task, a map is used to store words of dictionary along with their frequencies in database.txt file( EBook of The Adventures of Sherlock Holmes by Sir Arthur Conan Doyle).
3. Following operations are performed on the given input word - deletion, transposition, alteration, insertion.
4. Answer is determined by the word with maximum frequency in the map.

e.g.
1) covard - coward
2) happines - happiness
3) abte - able
4) reconcilation - reconciliation
5) troble - trouble

How To run the code :

1. Windows: Compile and run the "spell_corrector.cpp" by any C++ compiler eg. devc++, codeblocks.
   Linux :
		a) Install g++
		b) Compile using command - g++ spell_corrector.cpp -o spell_corrector 
		c) Run file using command - ./spell_corrector

2. Enter the word for which you want to spell correct.

