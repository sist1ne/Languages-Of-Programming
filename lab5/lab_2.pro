DOMAINS
	list = integer*
	lowest = integer
	size = integer
PREDICATES
	nondeterm generateL (list, size)
	nondeterm minOdd(integer, integer, integer)
	nondeterm searchMin(list, lowest)
	nondeterm printRes(integer)
CLAUSES
	generateL ([], 0) :- !.
	generateL ([Num|List], Size) :-
		Size > 0,
		Write("Input element of list: "), readint(Num),
		DecSize = Size - 1,
		generateL (List, DecSize).
	
	searchMin([Elem], Elem).
	searchMin([Head|Tail], TempMin) :-
		searchMin(Tail, MinTail), 
		minOdd(Head, MinTail, TempMin).
		
	minOdd(First, Second, First) :- %if the first is less than the second and both are odd
		First mod 2 <> 0, Second mod 2 <> 0,
		First<Second, !. 
	minOdd(First, Second, Second) :- %if the second is less than the first and both are odd
		First mod 2 <> 0, Second mod 2 <> 0,
		First>Second, !. 
	minOdd(First, _, First) :- %if only the first is odd
		First mod 2 <> 0, !.	
	minOdd(_, Second, Second).
		
	printRes(Num) :-
		Num mod 2 <> 0, 
		write("Lowest odd num in the list: ", Num), nl, !.
	printRes(_) :- 
		write("There is no odd numbers in the list."), nl.		
GOAL
	Write ("Input size of list: "), readint(Size),
	generateL (List, Size), nl,
	Write("List: ", List), nl, 
	
	searchMin (List, Result),
	printRes(Result),
	Write ("---------------------------------------"), nl.