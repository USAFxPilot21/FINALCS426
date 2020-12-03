:::::::::::::::::::::::::::::
:: 
:::::::::::::::::::::::::::::

:: Run good test cases
echo Jesse Sidhu and Josiah Goosen's Automated Test Cases > results.txt
echo. >> results.txt
echo ################################### >> results.txt
echo ----------------------------------- >> results.txt
echo Running Correct Test Cases >> results.txt
echo ----------------------------------- >> results.txt
echo ################################### >> results.txt
echo. >> results.txt

::Testing Assignment Statements Below
echo ----------------------------------- >> results.txt
echo Testing Assignment Statement >> results.txt
echo ----------------------------------- >> results.txt
echo. >> results.txt

echo Testing Assignment Statement >> results.txt
bin\Debug\ConsoleApplication.exe tests\assign.txt >> results.txt
echo. >> results.txt

::Testing Control Structures Below
echo ----------------------------------- >> results.txt
echo Testing Control Structures >> results.txt
echo ----------------------------------- >> results.txt
echo. >> results.txt

echo Testing Control Structures >> results.txt
bin\Debug\ConsoleApplication.exe tests\controlStruct.txt >> results.txt
echo. >> results.txt


::Testing Variable Declarations Below
echo ----------------------------------- >> results.txt
echo Testing Variable Declarations >> results.txt
echo ----------------------------------- >> results.txt
echo. >> results.txt

echo Testing Variable Declarations >> results.txt
bin\Debug\ConsoleApplication.exe tests\variableDec.txt >> results.txt
echo. >> results.txt


::Testing Math Below
echo ----------------------------------- >> results.txt
echo Testing Math >> results.txt
echo ----------------------------------- >> results.txt
echo. >> results.txt

echo Testing Math >> results.txt
bin\Debug\ConsoleApplication.exe tests\math.txt >> results.txt
echo. >> results.txt

::Testing Relational Operations Below
echo ----------------------------------- >> results.txt
echo Testing Relational Operations >> results.txt
echo ----------------------------------- >> results.txt
echo. >> results.txt

echo Testing Relational Operations >> results.txt
bin\Debug\ConsoleApplication.exe tests\relationalOper.txt >> results.txt
echo. >> results.txt


::Testing Procedures Below
echo ----------------------------------- >> results.txt
echo Testing Procedures >> results.txt
echo ----------------------------------- >> results.txt
echo. >> results.txt

echo Testing Procedures >> results.txt
bin\Debug\ConsoleApplication.exe tests\procedures.txt >> results.txt
echo. >> results.txt


::Testing Boolean Operators Below
echo ----------------------------------- >> results.txt
echo Testing Boolean Operators >> results.txt
echo ----------------------------------- >> results.txt
echo. >> results.txt

echo Testing Boolean Operators >> results.txt
bin\Debug\ConsoleApplication.exe tests\bool.txt >> results.txt
echo. >> results.txt

::Start the output file
start results.txt