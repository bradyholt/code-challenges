# deadlock_detector
Reads an input file of process dependencies and prints GOOD or BAD to signify a deadlock.

A **deadlock** is a situation in which two or more competing actions are each waiting for the other to finish, and thus neither ever does.

For example if Process1 holds a lock to Resource1 and waits for a lock on Resource2 while Process2 holds a lock on Resource2 and waits for a lock on Resource1, neither of processes can continue.

**Input	format:**	Input	to	this	application	is	a	flat	comma	separated	file (specified as the first command line argument)	with	the following	format:
`<processId>,	<resourceId>,	<W	or	H>`.
`Process	Id`	and	`Resouce	Id`	are	two	integers	defining	the	process	and	resource.	  The	third	parameter	is	either	`W`	(Wait)	or	`H`	(Hold).

For	example:
```
1,1,H
1,2,W
2,1,W
2,2,H
```

This program reads an	input	file	as	command	line argument	and	writes	GOOD or	BAD	on	the	standard output depending	on	the	state	of	the	input	file.	If	the	input	 file	is	in	Deadlock	state	this program	will write	BAD	and	if	the	input	is	not	in	deadlock	state this program	will	write	GOOD.

## Example usage

```
ruby deadlock_detector.rb input_deadlocked.txt
>> BAD
```

```
ruby deadlock_detector.rb input_not_deadlocked.txt
>> GOOD
```

## Tests

RSpec tests are located in the /spec folder. 
