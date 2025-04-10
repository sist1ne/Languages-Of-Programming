PREDICATES
	nondeterm summ(integer, integer, integer)
CLAUSES
	summ(0, B, C) :- 
		Z=B+C, 
		write("res=", Z), !.
		
	summ(Num, 0, 0) :- 
		Num > 0,
		Z = Num div 10,
		LastNum = Num mod 10,
		summ(Z, 0, LastNum), !.
		
	summ(Num, Digit1, Digit2) :-
		Digit1 = Digit1, 
		Leftover = Num div 10,
		LastNum = Num mod 10,
		summ(Leftover, LastNum, Digit2), !.
GOAL
	write ("Input number: "), readint(Num),
	summ(Num, 0, 0), nl,
	write ("------------------"), nl.
