open System

printfn "����� ����������, ������������! ��� ��������� ��������� ����������� �������� ��� ��������."

// ������� ��� ���������� 
let rec start () = 
    printfn "1. �������� ��������"
    printfn "2. ����� �� ���������"
    printfn "�������� ��������: "

    let h = Console.ReadLine()

    try
        int h
    with
    | ex ->
        printfn "����������, �������� ��������."
        printfn ""

        start ()

// ������� ��� ����� ����� �� ������������
let rec numInput () = 
    try 
        float (Console.ReadLine())
    with 
        | :? System.FormatException ->
            printfn "�������� ����. ����������, ������� �����: "
            numInput () // ����������� ����� ��� ���������� �������
        | ex ->
            printfn "��������� ������������! ������� �����: "
            numInput ()    

// ������� ��� �������� ������
let randList N =
    [ 
        for i in 1 .. N do
            yield (float(i*10) + float(N*2) + float(N-i))
    ]

// ������� ��� ���������� � ������ ������
let addList listik num = 
    num :: listik

// ������� ��� �������� �� ������
let rec delList listik num = 
    match listik with 
    | [] -> []
    | head :: tail when head = num -> tail
    | head :: tail -> head :: delList tail num 

// ������� ��� ������ �� ��������
let rec findList listik num = 
    match listik with 
    | [] -> false 
    | head :: tail when head = num -> true
    | head :: tail -> findList tail num 

// ������� ��� ������ �������
let uniteList listik1 listik2 = 
    listik1 @ listik2

// ������� ��� ������ �� ������
let rec lookList listik id = 
    if (id-1) >= List.length(listik) then 
        printfn "����� ������ ���������� ����� � ������! ������� �����: "
        let new_id = int(numInput ())
        lookList listik new_id
    elif (id-1) < 0 then 
        printfn "����� �� ����� ���� ������ 1! ������� �����: "
        let new_id = int(numInput ())
        lookList listik new_id
    else 
        listik[id-1]

let rec cycleWork () = 
    let help = start () 

    if help = 1 then 
        printfn "�������� '����������' ������"
        printfn "������� ����������� ������: "
        let N = int(numInput ())
        let sp1 = randList N

        // ����������
        printfn "���������� ��������"
        printfn "C�����: %A" sp1
        printfn "������� ����������� �����: "
        let adder = numInput ()

        let sp2 = addList sp1 adder 
        printfn "C����� ����� ���������� �������� � ������: %A" sp2
        printfn ""

        // ��������
        printfn "�������� ��������"
        printfn "C�����: %A" sp2
        printfn "������� ��������� �����: "
        let deleter = numInput ()

        let sp3 = delList sp2 deleter
        printfn "C����� ����� �������� ��������: %A" sp3
        printfn ""

        // ����� ��������
        printfn "����� ��������"
        printfn "C�����: %A" sp3
        printfn "������� ��������� �����: "
        let finder = numInput ()

        let isItThere = findList sp3 finder
        printfn "���������� ����� %f: %b" finder isItThere
        printfn ""

        // ������ ���� �������
        printfn "������ ���� �������"
        printfn "C����� 1: %A" sp3
        printfn "������� ����������� ��� ������ 2:"
        let N2 = int(numInput ())
        let sp_add = randList N2

        printfn "C����� 2: %A" sp_add

        let sp4 = uniteList sp3 sp_add
        printfn "������������ ������: %A" sp4
        printfn ""

        // ����� �� �������� �������������� 
        printfn "����� �������� �� ������"
        printfn "C�����: %A" sp4
        printfn "������� �����:"
        let id = int(numInput ())

        let elem = lookList sp4 id
        printfn "������� �� ������ %d: %f" id elem
        printfn ""

        cycleWork ()
    elif help = 2 then
        printfn "���������� ������..."
        printfn ""

        exit 0
    else
        printfn "����������, �������� ��������."
        printfn ""

        cycleWork ()

let main = 
    cycleWork ()
    0