

delete from [FP].[User]
insert into FP.[User] (UserID, ParentID,PayeeID,L1,JoinDateTime) select 'wigiwiz', 'wigiwiz', 'wigiwiz',2, '2019-03-03 00:00:01.000'
insert into FP.[User] (UserID, ParentID,PayeeID,L1,JoinDateTime) select 'dougraley', 'wigiwiz', 'wigiwiz',0, '2019-03-03 00:00:02.000'
insert into FP.[User] (UserID, ParentID,PayeeID,L1,JoinDateTime) select 'joleneknight', 'wigiwiz', 'wigiwiz',0, '2019-03-03 00:00:03.000'

declare @return int;
exec @return = [FP].[User_Insert] 'wigiwiz', '0101'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] '0101', '0201'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] '0201','0301'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] '0301','0401'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] '0401','0501'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] '0501','0601'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] '0601','0701'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] '0201','0702'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] '0501','0602'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] '0602','0703'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] 'joleneknight','0202'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] '0202','0302'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] '0302','0402'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] '0402','0502'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] '0502','0603'
select [Return Value] = @return;

--declare @return int;
exec @return = [FP].[User_Insert] '0502','0604'
select [Return Value] = @return;

declare @return int;
exec @return = [FP].[User_Insert] 'dougraley','0203'
select [Return Value] = @return;

declare @return int;
exec @return = [FP].[User_Insert] '0203','0303'
select [Return Value] = @return;

declare @return int;
exec @return = [FP].[User_Insert] '0303','0403'
select [Return Value] = @return;

declare @return int;
exec @return = [FP].[User_Insert] '0403','0503'
select [Return Value] = @return;

declare @return int;
exec @return = [FP].[User_Insert] '0503','0605'
select [Return Value] = @return;