open System 

printfn "����� ����������! \n��� ��������� ��������� � ������ ������� �������� ������ �������� ������!"

//����������� ������� ��� ������� � �������������
let rec Menu () = 
    printfn "\n��� ��������� ������?"
    printfn "1. ������ �����������"
    printfn "2. ��������� �����������"
    printfn "----------------------------------------"
    printfn "3. ����� �� ���������"
    printfn "\n�������� ��������: "

    let line = Console.ReadLine()

    if line = "1" then 1
    elif line = "2" then 2 
    elif line = "3" then 3
    else 
        printfn "����������, �������� ��������! \n"
        Menu ()

//����������� ������� ��� ������� � �������� ����������� ������������� �������
let rec AddInput () =  
    printfn "\n������� ������, ������� ������ �������� � ������ ������� ��������: "
    let succ, res = Char.TryParse(Console.ReadLine())

    if succ = true then 
        res
    else 
        printfn "������� ���� ������!"
        AddInput ()

//����������� ������� ��� ������� � �������� ����������� ������������� ���������� ���������
let rec N () = 
    printf "������� ���������� ��������� ��� ������: "
    let succ, res = Int32.TryParse(Console.ReadLine())

    if succ = true then 
        if (res >= 0) then 
            res
        else 
            printfn "���������� ��������� �� ����� ���� �������������! \n"
            N ()
    else 
        printfn "����������, ������� �����! \n"
        N ()

//������� ��� ������ ������
let Print (spisok) = 
    printf "%A" spisok

//������� ��� ������� ���������� ������, ������������ ����������� ������
let HandZ (n) =
    [
        for i in 1..n do 
            printf "������� %d ������� ������: " i
            yield Console.ReadLine()
    ]

let alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTYVWXYZ�������������������������������������Ũ��������������������������0123456789" 
let alp_size = 128

//������� ��� ���������� ���������� ������, ������������ ����������� ������
let RandZ (n) =
    [
        for i in 1..n do                                            //���� ��� ���������� ������ �� ����� 
            let sentence_size = Random().Next(1, 6)

            let sentence = [                            //������ �� ����
                for j in 1..sentence_size do                        //���� ��� ���������� ������ �� ���� 
                    let word_size = Random().Next(1, 6)
                    let word = [                        //������ �� ����
                        for k in 1..word_size do                    //���� ��� ���������� ������ �� �������� 
                            let temp = Random().Next(0, alp_size-1) 
                            yield alphabet[temp]
                    ]
                    yield String.Concat(word)       //�������������� ������ �� ���� � ��� ������ string � ���������� � ������ �� ����
            ]
            yield String.Join(" ", sentence)       //�������������� ������ �� ���� � ������ � ������������� � ���������� � ������ �� �����
    ]

//������� ��� ���������� ������� � ������ ������� �������� ������
let AddFront (theList:string list) (symbol:char) = 
    let add = string(symbol)
    List.map (fun el -> add + el) theList

//����������� ������� ��� ��������� ������ ���������
let rec CycleWork () =
    let temp = Menu ()

    if temp = 1 then
        let num = N ()
        let spisok = HandZ (num)
        printf "\n�������������� ������: "
        Print (spisok)

        let spisok1 = AddFront spisok (AddInput ())  //���������� ������������ ������ � ����������� ������� � ������ ������� ��������

        printf "\n��������� ����������: "
        Print (spisok1) 
        printf "\n========================================"

        CycleWork () 

    elif temp = 2 then 
        let num = N ()
        let spisok = RandZ (num)
        printf "\n�������������� ������: "
        Print (spisok)

        let spisok1 = AddFront spisok (AddInput ())  //���������� ������������ ������ � ����������� ������� � ������ ������� ��������

        printf "\n��������� ����������: "
        Print (spisok1) 
        printf "\n========================================"

        CycleWork () 

    elif temp = 3 then
        exit 0 

let main = 
    CycleWork ()

    0