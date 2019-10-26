from flask import Flask
import pyodbc
import json

conn = pyodbc.connect('Driver={ODBC Driver 17 for SQL Server};'
                      'Server=w4rta-host.database.windows.net;'
                      'Database=W4rtaDB;'
                      'UID=Bird;'
                      'PWD=roman-IBD;')

app = Flask(__name__)


@app.route('/')
def hello_world():
    return "Go to /test"


@app.route('/test')
def test():
    cursor = conn.cursor()
    data = cursor.execute('SELECT TOP (?) * FROM dbo.ADDRESS;', [1000])
    rows = data.fetchall()
    results = []
    for row in rows:
        results.append([x for x in row])
    return json.dumps(results)