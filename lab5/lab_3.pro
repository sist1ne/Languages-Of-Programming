DOMAINS
	list = integer*
	size = integer
PREDICATES
	nondeterm generateL (list, size)
	
	nondeterm delete (integer, list, list)
	nondeterm listToSet (list, list)
	
	nondeterm isMember (integer, list)
	nondeterm intersec (list, list, list)
	nondeterm union (list, list, list)
	
	nondeterm calculationPrint(list, list, list)
	%determ printRes(list, list)
CLAUSES
	generateL ([], 0) :- !.
	generateL ([Num|List], Size) :-
		Size > 0,
		write("Input element of list: "), readint(Num),
		DecSize = Size - 1,
		generateL (List, DecSize).
		
	delete(_, [], []).
	delete(Head, [Head|List], List1) :- 
		delete(Head, List, List1).
	delete(Head, [Temp|List], [Temp|List1]) :- 
		Head<>Temp,
		delete(Head, List, List1).
		
	listToSet([], []).
	listToSet([Head|Tail], [Head|T1]) :-
		delete(Head, Tail, Tail2),
		listToSet(Tail2, T1).
		
	isMember(Num, [Num|_]).
	isMember(Num, [_|Set]) :- isMember(Num, Set).
	
	union([], Set2, Set2).
	union([Head|Tail], Set2, Set) :-
		isMember(Head, Set2), !,
		union(Tail, Set2, Set).
	union([Head|Tail], Set2, [Head|Set]) :-
		union(Tail, Set2, Set).
	
	intersec([], _, []).
	intersec([Head|T1], Set2, [Head|Tail]) :-
		isMember(Head, Set2), !,
		intersec(T1, Set2, Tail).
	intersec([_|Tail], Set2, Set) :-
		intersec(Tail, Set2, Set).
		
	calculationPrint(SetA, SetB, SetC) :-
		%left part of the equation
		union(SetB, SetC, UnionSet),
		intersec(SetA, UnionSet, Result1),
	
		%right part of the equation
		intersec(SetA, SetB, InterSet1),
		intersec(SetA, SetC, InterSet2),
		union(InterSet1, InterSet2, Result2),
		
		write(Result1, " must be equal to ", Result2), nl, nl.
			
GOAL
	write ("Input size of list A: "), readint(Size1),	
	generateL (ListA, Size1),
	write("The first list: ", ListA), nl, nl,
	
	write ("Input size of list B: "), readint(Size2),	
	generateL (ListB, Size2),
	write("The second list: ", ListB), nl, nl,
	
	write ("Input size of list C: "), readint(Size3),	
	generateL (ListC, Size3),
	write("The third list: ", ListC), nl, nl, 
	
	listToSet (ListA, SetA),
	listToSet (ListB, SetB),
	listToSet (ListC, SetC),
	write("Set A: ", SetA), nl, 
	write("Set B: ", SetB), nl, 
	write("Set C: ", SetC), nl, nl,
	
	calculationPrint(SetA, SetB, SetC),

	write ("-------------------------------------"), nl.