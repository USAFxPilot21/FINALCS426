:: * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
:: * This file is part of SableCC.                             *
:: * See the file "LICENSE" for copyright information and the  *
:: * terms and conditions for copying, distribution and        *
:: * modification of SableCC.                                  *
:: * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
::
:: IMPORTANT: Put the absolute path to sablecc.jar below.
::
:: java -jar "LOCATION_OF_SABLECC.JAR-MAY_REQUIRE_QUOTES" -t csharp,csharp-build NAME_OF_GRAMMAR_FILE

java -jar "C:\Users\C21Jesse.Sidhu\Desktop\sablecc-3-beta.3.altgen.20041114\lib\sablecc.jar" -t csharp,csharp-build simple.grammar
pause
del test_parser.cs
del test_lexer.cs 