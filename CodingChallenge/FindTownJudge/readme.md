Find the town judge
---------------------

In a town, there are n people labelled from 1 to n.  There is a rumor that one of these people is secretly the town judge.

If the town judge exists, then:
1. The town judge trusts nobody.
1. Everybody (except for the town judge) trusts the town judge.

There is exactly one person that satisfies properties 1 and 2.

You are given trust, an array of pairs trust[i] = [a, b] representing that the person labelled a trusts the person labelled b. If the town judge exists and can be identified, return the label of the town judge.  Otherwise, return -1.


Examples
-----------------

    Input: n = 2, trust = [[1,2]]  
    Output: 2

    Input: n = 3, trust = [[1,3],[2,3]]  
    Output: 3

    Input: n = 3, trust = [[1,3],[2,3],[3,1]]  
    Output: -1

    Input: n = 3, trust = [[1,2],[2,3]]  
    Output: -1

    Input: n = 4, trust = [[1,3],[1,4],[2,3],[2,4],[4,3]] // 1,2 and 4 trust 3 but 3 doesn't trust anybody  
    Output: 3
    