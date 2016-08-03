## Dead-lock	detection

A **deadlock** is a situation in which two or more competing actions are each waiting for the other to finish, and thus neither ever does.

For example if Process1 holds a lock to Resource1 and waits for a lock on Resource2 while Process2 holds a lock on Resource2 and waits for a lock on Resource1, neither of processes can continue.

In	this	example	you	are	writing	a	program	that	detects	deadlock	in	a	list	of	 processes	and	resources.

**Input	format:**	Input	to	this	application	is	a	flat	comma	separated	file	with	the following	format:
`<processId>,	<resourceId>,	<W	or	H>`
`Process	Id`	and	`Resouce	Id`	are	two	integers	defining	the	process	and	resource.	
The	third	parameter	is	either	`W`	(Wait)	or	`H`	(Hold).

For	example, here is	the	input	file	for	the	deadlock	example	in	the	definition:
```
1,1,H
1,2,W
2,1,W
2,2,H
```
You	are	writing	a	program	in	Ruby to	read	the	input	file	as	command	line	argument	and	write	GOOD	 or	BAD	on	the	standard	output	depends	on	the	state	of	the	input	file.	If	the	input	 file	is	in	Deadlock	state	application	should	write	BAD	and	if	the	input	is	not	in	deadlock	state application	should	write	GOOD.

*Hint:	Convert	the	input	to	a	directed	graph.	Wait	and	Hold	shows	the	direction	of	the	edge	and	then	look	for	loops	in	the	graph.	Loops	in	the	graph	represent deadlocks.*

- Please	do	not	use	any	pre	written	library	for	loop	detection.
- Please	accompany	your	answer	with	proper	test	coverage.
- Please	abstract	the	general	graph theory	algorithm	from	your	specific	
problem	code.
