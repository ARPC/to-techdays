import pyodbc
import sys
import string

def PrintFirstNames(lastName):
    connection =\
        pyodbc.connect("DRIVER={ODBC Driver 17 for SQL Server}; Server=tcp:qasql.arpcdev.local;uid=test;pwd=test;database=toqatrunk;")
    
    cursor = connection.cursor()

    queryTemplate = string.Template("select * from exposed where lastName = '$lastName';")
    query = queryTemplate.substitute(lastName=lastName)

    cursor.execute(query)
    row = cursor.fetchone()

    while row:
        print row.FirstName
        row = cursor.fetchone()
    
PrintFirstNames('Ingram')

# Using SQL Server from MacOS Python
# Install homebrew 
# --> /usr/bin/ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"
# Install python 2
# --> brew install python@2
# Test it: 
# -- > python --version 
# Shoule be 2.7.14
# Upgrade pip
# --> pip install --upgrade pip
# Install pyodbc
# --> pip install pyodbc
# Install MS ODBC driver
# --> brew tap microsoft/mssql-release https://github.com/Microsoft/homebrew-mssql-release
# --> brew update
# -- > brew install --no-sandbox msodbcsql17 mssql-tools
# Install VSCode
# --> browse to https://code.visualstudio.com/docs?dv=osx
# --> Open downloaded zip
# --> Drag the app to applications
# Start programming & Have Fun
