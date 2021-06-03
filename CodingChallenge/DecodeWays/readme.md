A message containing letters from A-Z can be encoded into numbers using the following mapping:

'A' -> "1"
'B' -> "2"
...
'Z' -> "26"

To decode an encoded message, all the digits must be mapped back into letters using the reverse of the mapping above (there may be multiple ways). For example, "111" can have each of its "1"s be mapped into 'A's to make "AAA", or it could be mapped to "11" and "1" ('K' and 'A' respectively) to make "KA". Note that "06" cannot be mapped into 'F' since "6" is different from "06".

Given a non-empty string num containing only digits, return the number of ways to decode it.

      1234
|              |
234            34
|       |     |   |
34      4     4  null
|  |    |     |
4 null null  null


1234
    1 -> 234
        2 -> 34
            3 -> 4
                4 -> null
            34 -> null
        23 -> 4
            4 -> null
    12 -> 34
        3 -> 4
            4 -> null
        34 -> null

 1  2  3  4
[2+1, 1+1, 1+0, 1]
nums = 3
= 1,2,3,4 12,3,4 1,23,4 

 2, 2, 2, 2
[3+2, 2+1, 1+1, 1]
= 5
- 2,2,2,2 | 22,2,2 | 2,22,2 | 2,2,22 | 22,22



