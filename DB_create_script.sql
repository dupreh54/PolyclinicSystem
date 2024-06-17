create database PolyclinicDB

use PolyclinicDB

GO
create table [Role](
id int identity primary key,
title nvarchar(50)
)

create table [User](
id int identity primary key,
login nvarchar(20) unique,
password nvarchar(50),
userRoleId int foreign key references [Role](id) default(1),
medicalPolicy nvarchar(16),
phoneNumber nvarchar(50),
name nvarchar(50),
surname nvarchar(50),
patronymic nvarchar(50)
)

create table Position(
id int identity primary key,
title nvarchar(50)
)

create table DoctorsPosition(
id int identity primary key,
userId int foreign key references [User](id), 
positionId int foreign key references Position(id)
)

create table Schedule(
id int identity primary key,
userId int foreign key references [User](id),
cabinet int,
timeStart datetime,
timeEnd datetime,
appointmentTime time not null,
positionId int foreign key references Position(id)
)

create table TicketState(
id int identity primary key,
title nvarchar(30)
)

create table AdmissionTicket(
id int identity primary key,
patientId int foreign key references [User](id),
specialistId int foreign key references [User](id),
receiptDate datetime,
complaints nvarchar(200),
cabinet int,
doctorPositionId int foreign key references Position(id),
currentStateId int foreign key references TicketState(id),
appointmentResult nvarchar(max)
)

insert into TicketState(title)
values ('Зарегистрировано'), ('Обрабатывается'), ('Отклонено'), ('Завершено'), ('Просрочено')

insert into [Role](title)
values('Пациент'), ('Врач'), ('Регистратор'), ('Администратор'), ('Главврач')

insert into Position(title)
values ('Терапевт'), ('Кардиолог'),
('Уролог'), ('ЛОР'),
('Офтальмолог'), ('Фтизиатр'),
('Эндокринолог'), ('Хирург'),
('Невролог'), ('Травматолог'),
('Ортопед'), ('Инфекционист'),
('Ревматолог'), ('Гастроэнтеролог'),
('Пульмонолог'), ('Нефролог'),
('Проктолог'), ('Гериатр')


insert into [User](login, password, userRoleId, name, surname, patronymic, medicalPolicy, phoneNumber) 
values 
('patient', 'patient', 1,'Пётр','Иванов', 'Петрович','5432656632549865', '89006545646'),
('patient2', 'patient2', 1,'Фёдор','Скворцов', 'Иванович','4332543254986545', '89006545646')

insert into [User](login, password, userRoleId, name, surname, patronymic) 
values
('reception', 'reception', 3,'Вячеслав','Павлов', 'Вячеславович'),
('admin', 'admin', 4,'Юрий','Сверлов', 'Алексеевич'),
('maindoctor', 'maindoctor', 5,'Иосиф','Главный', 'Александрович'),
('doctor', 'doctor', 2,'Василий','Врачебный', 'Васильевич'),
('doctor1', 'doctor1', 2,'Владимир','Петров', 'Александрович'),
('doctor2', 'doctor2', 2,'Егор','Суслов', 'Алексеевич'),
('doctor3', 'doctor3', 2,'Валерий','Иванов', 'Алексеевич');

insert into DoctorsPosition(userId, positionId)
values(6,1),(7,1),(8,2),(9,2)

insert into Schedule(userId, cabinet, timeStart, timeEnd, appointmentTime,positionId)
values(6, 54, '2024-06-05T12:00:00', '2024-06-05T18:00:00','00:15:00',1),
(6, 54, '2024-06-06T12:00:00', '2024-06-06T18:00:00','00:15:00',1),
(6, 54, '2024-06-07T12:00:00', '2024-06-07T18:00:00','00:15:00',1),
(7, 27, '2024-06-05T09:00:00', '2024-06-05T18:00:00','00:15:00',1),
(8, 33, '2024-06-05T09:00:00', '2024-06-05T18:00:00','00:40:00',2),
(9, 11, '2024-06-05T09:00:00', '2024-06-05T18:00:00','00:50:00',2)

insert into AdmissionTicket(patientId, specialistId, receiptDate, doctorPositionId, currentStateId,appointmentResult, complaints, cabinet)
values(1,6,'2024-04-18T12:00:00',1,4,'Осмотр: состояние удовлетворительное, сознание ясное, пациент контакту доступен.
Кожа и видимые слизистые бледные, чистые. Температура на приеме 37,2оС. Носовое дыхание затруднено. ЧДД 17 в минуту. 

Немедикаментозная терапия:
ношение одежды по сезону;
обильное и теплое питье (лимон, имбирь, клюква, малина, мед);
покой, постельный режим;
дозированный режим труда и отдыха;
ограничение физических нагрузок;
проветривание помещения 3 раза в день;

Медикаментозная терапия:
Арбидол 200 мг 4 раза в сутки 5 дней
Caps. Ingavirini 90mg N 10 DS: По 90мг, 2 раза в день, 5 дней
Tab. Levofloxacini 500mg N 14 DS: По 500мг 2 раза в день, 7 дней
Tab. Amoxicillini + Clavulanici acidi 875mg/125mg N14 DS: По 1 таблетке, 2 раз в сутки, 7 дней',
'Общая слабость, быстрая утомляемость во второй
половине дня в течение последнего месяца. Последнюю неделю
повышенная температура тела которая сопровождается умеренной потливостью.', 454),
(1,6,'2024-04-18T12:00:00',1,3,NULL,
'Общая слабость, быстрая утомляемость во второй
половине дня в течение последнего месяца. Последнюю неделю
повышенная температура тела которая сопровождается умеренной потливостью.', 454),
(2,6,'2024-06-06T12:00:00',2,2,NULL,
'Температура 38, кашель, боль в горле', 454),
(2,6,'2024-06-06T13:45:00',2,4,NULL,
'Температура 38, кашель, боль в горле', 454),
(2,7,'2024-06-06T12:00:00',2,4,NULL,
'Температура 38, кашель, боль в горле', 457),
(2,7,'2024-06-06T12:30:00',2,4,NULL,
'Температура 38, кашель, боль в горле', 457),
(2,7,'2024-06-06T12:45:00',2,4,NULL,
'Температура 38, кашель, боль в горле', 457),
(2,6,'2024-06-06T13:15:00',2,4,NULL,
'Температура 38, кашель, боль в горле', 454),
(2,7,'2024-06-06T12:00:00',2,4,NULL,
'Температура 38, кашель, боль в горле', 457)
GO