# Quiz

## Introduction
This is a simple Quiz application which uses the Object-Oriented programming paradigm.
Questions can be of the following types,
- text based question
- true/false question
- multiple choice question

Data for the questions are loaded in from a csv file. The Quiz application is currently a console application. The code could be extended to include a graphical user interface (GUI).

### CSV file format
The format of the csv file is,

| Question type       | Question | Answer | Points        | Other options       |
|---------------------|----------|--------|---------------|---------------------|
| 1 - text based      | Text     | Text   | Number        |                     |
| 2 - true/ false     | Text     | Text   | Defaults to 1 |                     |
| 3 - multiple choice | Text     | Text   | Number        | ; separated options |



## Design
The code matches the design documents supplied in the tutorials. The tutorials originally were written for Java and this was translated into C# to as a demonstration. The code has been designed to be easy to maintain, expand and to stay as close as possible to the original Java version of the code. 


## Environment
The code was written in Microsoft Visual Studio Community 2022 Edition. The operating system used was Microsoft Windows 10 and 11.
