## Metrics-Project
### Creating a Function Point Calculator 


1-The program should calculate the function point as per the problem you will be given in the practical exam.

2-Input: You will be given a problem in a paper. you should list and count the function points, then enter them in your GUI as:
 ```bash
 -External Interface files
 -Internal Logical Files
 -External Input
 -External Output
 -External Inquiry
```
 -Your program shall accept the DI as an int input from the GUI.

3-Your program should store the complexity table values as static values (hard coded)
 <img src="https://www.praxisframework.org/images/function-point-analysis.png" align="middle">
 
4-By clicking “Calculate UFP” btn in your GUI, your program should calculate the total UFP (Unadjusted Function Points) using the following equation, then display it in the GUI:

                                  Total UFP = (number of elements of given type) × (weight)
              
5- Your program should store the TCF (Technical Complexity Factor) or GSC (General System Characteristic Section) as static values (hard coded) (in a dictionary for example)
<img src="https://image.slidesharecdn.com/bjmchapter2fpa-170908093152/95/function-point-analysis-fpa-by-dr-b-j-mohite-11-638.jpg?cb=1504863236" align="middle">
 
6-Then your program should calculate the DI for the 14-attributes based on the TCF.

7- By clicking “Calculate TCF” btn in your GUI, your program should calculate the total TCF using the following equation, then display it in the GUI:
                  
                                                TCF = 0.65 + (0.01 * DI)
                         
8-By clicking “Calculate FP” btn, your program should calculate the function point using the following equation, then display it in the GUI:
                      
                                                    FP = UFP * TCF
                           
9-Then your GUI shall list the AVC values for each language in DDL as follows to enable the user to select the loc based of the programming language.
 
 
10-Finally by clicking “Calculate FP” btn, your program should calculate the function point using the following equation, then display it in the GUI:
                        
                                                    LOC = AVC * FP
