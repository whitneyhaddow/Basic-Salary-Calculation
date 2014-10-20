Basic-Salary-Calculation
========================

A basic program to calculate federal tax on individual salaries. Also calculates the average and midpoint of up to 50 added salaries.

This program was created as part of an assessment for a limited amount of time. 
This code therefore is not the cleanest and possibly needs to be greatly improved.

The form allows the user to enter salary values (up to 50) which are stored in an array.
When each value is entered, the federal tax for that specific value is calculated and display. 
The calculations are based on the following:

If salary is 43561 or less, the tax is 15% of the salary.
If the salary is more than the previous but not more than 87123, the tax is 6534 plus 22% of the difference (salary minus 43561).
If the salary is  more than the previous, the tax is 16118 plus 26% of the difference (salary minus 87123).

When the user is done entering the salaries, the form will display both the average and midpoint of the salaries.
