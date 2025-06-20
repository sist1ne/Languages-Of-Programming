program test;
var
  i: integer;
  flag: boolean;
begin
  i := 4;
  flag := true;
  for j := 1 to 10 do
  begin
    if flag and (i < 10) then
      i := i - 1;
  end;
end.
