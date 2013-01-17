Time-Enigma-Resolver
====================

This a simple but efficient time enigma resolver, in c#


How to ?
=======

Fill a new Int array.
<pre>
int?[] numbers = new int?[]{ 2, 3, 1, 4, 2, 1, 4, 2, 4, 2, 2 };
</pre>

Launch the resolver
<pre>
/*
* @params int?[] The sequence
* @params bool True for multiple solution, false for the first found
*/
TimeEnigmaResolver tmr = new TimeEnigmaResolver(numbers,true);
</pre>


All solution are right padded.
