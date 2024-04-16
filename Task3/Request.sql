--Task 1
--Сотрудник с максимальной заработной платой.
SELECT TOP (1) * FROM Employee
ORDER BY [Salary] DESC


--Task 2
--Отдел с самой высокой заработной платой между сотрудниками.
--Не совсем понятно что нужно выводить поэтому привожу несколько решений
--как я интерпретировал данный вопрос

--Отдел в котором сотрудник с самой высокой ЗП
SELECT TOP (1) 
	d.Id, 
	d.Name
FROM Employee AS e
LEFT JOIN Department AS d ON d.Id = e.Department_Id
ORDER BY e.Salary DESC

--Отдел в котором самая высокая средняя ЗП
SELECT TOP(1)
	d.Id,
	d.Name,
	AVG(e.Salary) AverageSalary
FROM Department AS d
LEFT JOIN Employee AS e ON d.Id = e.Department_Id
GROUP BY 
	d.Id, 
	d.Name, 
	e.Department_Id
ORDER BY AVG(e.Salary) DESC

--Task 3
--Отдел с максимальной суммарной зарплатой сотрудников.
SELECT TOP(1)
	d.Id,
	d.Name,
	sum(e.Salary) SalarySum
FROM Department AS d
LEFT JOIN Employee AS e ON d.Id = e.Department_Id
GROUP BY 
	d.Id, 
	d.Name, 
	e.Department_Id
ORDER BY sum(e.Salary) DESC

--Task 4
--Сотрудника, чье имя начинается на «Р» и заканчивается на «н».
SELECT 
	* 
FROM Employee
WHERE
	Name like 'Р%н'
