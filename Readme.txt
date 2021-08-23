The basic idea here, is to read a file, with a log format as bellow:

312|200|HIT|"GET /robots.txt HTTP/1.1"|100.2
101|200|MISS|"POST /myImages HTTP/1.1"|319.4
199|404|MISS|"GET /not-found HTTP/1.1"|142.9
312|200|INVALIDATE|"GET /robots.txt HTTP/1.1"|245.1

And then, convert it to the new format, as showed bellow:

#Version: 1.0
#Date: 15/12/2017 23:01:06
#Fields: provider http-method status-code uri-path time-taken
response-size cache-status
"DESTINY_LOG" GET 200 /robots.txt 100 312 HIT
"DESTINY_LOG" POST 200 /myImages 319 101 MISS
"DESTINY_LOG" GET 404 /not-found 143 199 MISS
"DESTINY_LOG" GET 200 /robots.txt 245 312 REFRESH_HIT

"DESTINY_LOG" will make log files through specific URLs or Files.
The specification requires you to implement a Console Application that receives as input
an URL (sourceUrl), it could be a path in your computer and a destination file (targetPath).