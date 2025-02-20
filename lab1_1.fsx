open System

printfn "����� ����������, ������������! ��� ��������� ���������� �������� ��������� �����."

let rec start () = 
    printfn "1. ������ ���� �����"
    printfn "2. ����� �� ���������"
    printfn "�������� ��������: "

    let h = Console.ReadLine()

    try
        int h
    with
    | ex ->
        printfn "����������, �������� ��������."
        start ()

let rec getInput () =
    printf "������� �����, ��� ����������� ����� ������� 'stop' ��� 0: "
    let str = Console.ReadLine()

    if str <> "stop" then
        try
            int str
        with
        | :? System.FormatException ->
            printfn "�������� ����. ����������, ������� �����."
            getInput () 

        | ex ->
            printfn "��������� ������������!"
            getInput ()
    else 
        0

let rec listMaker num = 
    if num = 0 then 
        []
    else
       if num % 2 = 0 then
            true :: listMaker (getInput())
       else 
            false :: listMaker (getInput())

let show a = 
    printfn "�������������� ������: %A" a 

let rec cycleWork () = 
    let help = start () 

    if help = 1 then 
        let spisok = listMaker (getInput())
        printfn ""

        show spisok
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