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


-------------------------------------------------------
Suggestions for improvements
-------------------------------------------------------
1. Midpoint sounds like the median, maybe that statistic is more useful. Just sort the array and output the median salary.

2. When a salary is selected in the array, the Federal Tax field should be updated to display its value. Store the tax value for each salary, then bind the Federal Tax field to a property, CurrentDisplayedTax, for example. On that note, all fields should use data binding to update its values. Once a salary is entered, the average and midpoint are calculated without needing the Done button.

3. CalculateTax currently computes taxes for all salaries in the array every time it is called, but only returns the last computed tax value. This is highly inefficient, and should only need to compute tax for one salary upon method invoke. Furthermore, if tax values were stored for each salary, they would not need to be calculated again.

4. For better maintainability, federal tax brackets should be kept as variables instead of hard coded since every year brackets are adjusted for inflation and the like.

5. Added feature to calculate state tax for all states.

-------------------------------------------------------
Implementations
-------------------------------------------------------
Instead of using hard coded values for tax rates, a dictionary is used that maps tax rates to the ceiling value for each bracket, sorted on the keys. This data structure is preferable since different states may have different number of tax brackets, also changes to the ceiling values in each bracket may occur each year to adjust for inflation. Thus, changes will only need to be made to the brackets themselves, instead of to the functions for calculating tax. This improves maintainability and modularity.

The approach for calculating tax was changed. Instead of iterating through all of the salary and computing taxes for all of them every time, the functions perform the calculations on a given salary. The appropriate bracket will be used (either federal or state), and the computation simply accumulates the tax by enumerating through the sorted dictionary structure in ascending tax rates until the entire salary amount is taxed. The calculation calls the same method for federal and state. This improves testability: if it works for federal, it works for state.

An extra input field was added to the form to gather the state for which to compute state income tax. The resulting value is displayed to a new label field. A sorted bracket dictionary was similarly constructed for each state, with differing rates and number of brackets. The most recent data was found at http://taxfoundation.org/article/2016-tax-brackets for federal and http://taxfoundation.org/article/state-individual-income-tax-rates-and-brackets-2016 for states. All dictionaries are stored within a lookup dictionary, mapped to by its 2-letter state code in string format.

--------------------------------------------------------
Test Cases
--------------------------------------------------------
1. Input a salary that is in the first bracket, $7,000. The Calculated Federal Tax should be 700, and the Calculated State Tax for CA should be 70. This tests CalculateTax function for dealing with salary ranges in the first bracket.

2. Input a salary whose value lies on the ceiling of a bracket, $91,150. The Calculated Federal Tax should be 18558.75, and the Calculated State Tax for AZ should be 3275.76. This tests CalculateTax function for dealing with salaries that happen to be bracket ceiling values.

3. Input a salary that is in the last bracket, $500,000. The Calculated Federal Tax should be 154169.95, and the Calculated State Tax for FL should be 0. This tests CalculateTax function for dealing with salary ranges in the last bracket. At the same time, this tests CalculateTax function when a state like FL does not collect state income tax.

4. Perform error checking. Try to press Done button before entering the first salary entry. Expected output is "Please enter at least 1 salary." Try to press Next button without a salary entry or any non-numeric text. Expected output is "Salary has to be a numeric value." Enter an invalid numeric salary entry, -1. Expected output is "Salary must be higher than 0." Enter a valid numeric value for salary. Try to press Next button without a valid 2-letter state code. Expected output is "Please enter a valid 2-letter state code." Enter a valid 2-letter state code. Enter 50 valid salary entries, which is the max allowed. Try to enter another valid salary entry and click Next. Expected output is "You cannot enter any more salary values." The Next button should now be disabled. This tests input value error checking for the entire form. 

5. This tests the remaining portions on the form: average and midpoint display fields. A few valid entries are entered, the Done button is clicked, and the average and midpoint fields are validated. This tests the correctness of the remaining operations in the class: Sum, Min, and Max.
