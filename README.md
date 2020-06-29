### Write a program to retrieve and report various stock information for given days.
Query for the stock information using one of the following queries:

* https://jsonmock.hackerrank.com/api/stocks: This query returns all available stock information. The response is paginated so you may need to query https://jsonmock.hackerrank.com/api/stocks/?page=pageNumber, where pageNumber is an integer that describes the page number to view (e.g., 1, 2, etc.).
* https://jsonmock.hackerrank.com/api/stocks/?key=value: This query returns all results where the searched key has exact matching value. The response is paginated, so you may need to query https://jsonmock.hackerrank.com/api/stocks/?key=value&page=pageNumber, where pageNumber is an integer that describes the page number to view (e.g., 1, 2, etc.).
* https://jsonmock.hackerrank.com/api/stocks/search?key=value: This query returns all the results where the searched key has values that contains value as a substring. The response is paginated, so you may need to query https://jsonmock.hackerrank.com/api/stocks/search?key=value&page=pageNumber, where pageNumber is an integer that describes the page number to view (e.g., 1, 2, etc.).

Each of the queries returns a JSON response with the following _five_ fields:

* **page**: The current page number.
* **per_page**: The maximum number of results per page.
* **total**: The total number of response.
* **total_pages**: The total number of pages which must be queried to get all the results.
* **data**: An array of JSON objects that contains the stock information.  The JSON contains the following _five_ fields, which could be used as the key to query:
   
  * **date**: A string that describes the date on which the stock information is provided. The date format is d-mmm-yyyy , where d describes a valid day of the month, mmm describes the complete name of the month (e.g. , January , February , March , etc.), and yyyy describes the year. The date is in the range 5-January-2000 to 1-January-2014 inclusive. There could be no information provided for some of the dates and the information is available for Monday to Friday only.
  * **open**: A float value that describes the stock open price on the given date.
  * **close**: A float value that describes the stock close price on the given date.
  * **high**: A float value that describes the stock highest price on the given date.
  * **low**: A float value that describes the stock lowest price on the given date.

To solve this challenge, complete the function _openAndClosePrices_, which has three string parameters: _firstDate_, _lastDate_, and _weekDay_. Query for the stock _open_ and _close_ prices on each date when the weekday is _weekDay_ if the stock information is available. The stock information on each date should be printed on a new line that contains the three space separated values that describe the date, the open price, and the close price respectively. The order of the dates in the output does not matter.

**Function Description**
Complete the _openAndClosePrices_ function in the editor below. It must perform the operations described above and print the required information. There is no return value expected.

_openAndClosePrices_ has the following parameters:
-_firstDate_: a date string in the format described above
-_lastDate_: a date string in the format described above
-_weekday_: a string that represents the day of week to query

**Constraints**
_weekday_ will be one of the following: _[Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday]_

**Sample Input For Custom Testing**<br>
`1-January-2000 22-February-2000 Monday`

**Sample Output**

17-January-2000 5617.7 5404.07<br>
31-January-2000 5338.67 5205.29<br>
7-February-2000 5431.55 5474<br>
14-February-2000 6130.23 5924.31<br>
21-February-2000 5874.25 5876.89<br>
