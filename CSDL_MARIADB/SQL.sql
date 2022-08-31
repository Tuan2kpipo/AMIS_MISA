INSERT INTO Positions (PositionId, PositionName)
VALUES(UUID(), 'Phòng đào tạo');

INSERT INTO Positions (PositionId, PositionName)
VALUES(UUID(), 'Phòng nhân viên');

INSERT INTO Employee(EmployeeId, EmployeeCode, EmployeeName, IndentityNumber, Email,PhoneNumber, PositionId)
VALUES (UUID(), 'NV_0001','Nguyễn Đức Tuân', '12345678','tuan2k@gmail.com', '0273613212', 'f4c441fd-1477-11ed-82ee-0259e1bc84a2');


INSERT INTO Employee(EmployeeId, EmployeeCode, EmployeeName, IndentityNumber, Email,PhoneNumber, PositionId)
VALUES (UUID(), 'NV_0002','Nguyễn Đức Nopin', '12345678','nopin2k@gmail.com', '027361322', 'f4d07efb-1477-11ed-82ee-0259e1bc84a2');

SELECT * FROM Positions ;

SELECT * FROM Employee e;

SELECT e.EmployeeId, e.EmployeeCode, e.EmployeeName, e.IndentityNumber, e.Email, e.PhoneNumber, p.PositionId, p.PositionName
 FROM Employee e LEFT JOIN Positions p ON e.PositionId = p.PositionId;

DELETE FROM Positions WHERE PositionId = 'f4c441fd-1477-11ed-82ee-0259e1bc84a2';

DELETE FROM Employee;
DELETE FROM Positions;
