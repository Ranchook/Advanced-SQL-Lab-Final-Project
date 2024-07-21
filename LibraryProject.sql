drop table IF EXISTS login_log;
drop table IF EXISTS restore_pass;
drop table IF EXISTS users;
drop table IF EXISTS restore_questions;

drop table IF EXISTS books;
drop table IF EXISTS genre;
drop table IF EXISTS loan_log;
-------------------------------------------------

CREATE TABLE users (
  email VARCHAR(255) PRIMARY KEY,
  first_name varchar(20) NOT NULL,
  last_name varchar(20) NOT NULL, 
  birth_date DATE,
  pass VARCHAR(255) NOT NULL,
  connection_status tinyint not null, /*0 - blocked, 1 - success, 2 - fail*/
  status_update_time datetime not null,
  last_successful_login datetime not null,
  user_role tinyint not null, /*1 - guest user, 2 - connected user, 3 - system manager*/
  CHECK (email LIKE '_%@_%._%')
);

CREATE TABLE login_log (
  id int IDENTITY(1,1) PRIMARY KEY,
  email VARCHAR(255),
  log_time datetime,
  is_success BIT NOT NULL,
  FOREIGN KEY (email) REFERENCES users(email) ON DELETE CASCADE ON UPDATE CASCADE 
);

CREATE TABLE restore_questions (
  question_number INT PRIMARY KEY,
  question VARCHAR(255)
);

CREATE TABLE restore_pass(
  email VARCHAR(255),
  FOREIGN KEY (email) REFERENCES users(email) ON DELETE CASCADE ON UPDATE CASCADE,
  question_number INT, 
  answer VARCHAR(255),
  FOREIGN KEY (question_number) REFERENCES restore_questions(question_number),
  PRIMARY KEY (email, question_number)
);

-- Create table for book genres with name as the primary key
CREATE TABLE genre (
  name VARCHAR(50) PRIMARY KEY
);

-- Create table for books
CREATE TABLE books (
  book_id INT PRIMARY KEY IDENTITY(1,1),
  book_name VARCHAR(255) NOT NULL,
  author_name VARCHAR(255) NOT NULL,
  genre_name VARCHAR(50),
  year_published INT,
  is_loaned BIT NOT NULL DEFAULT 0,
  FOREIGN KEY (genre_name) REFERENCES genre(name)
);

-- Create table for loan logs
CREATE TABLE loan_log (
  id INT PRIMARY KEY IDENTITY(1,1),
  book_id INT,
  email VARCHAR(255),
  loan_date smalldatetime,
  loan_return_date smalldatetime,
  is_returned BIT NOT NULL DEFAULT 0,
  FOREIGN KEY (book_id) REFERENCES books(book_id),
  FOREIGN KEY (email) REFERENCES users(email) ON DELETE CASCADE ON UPDATE CASCADE
);
--------------------------------------------------------------------------------


--=========================== insert genres ==================================

INSERT INTO genre (name) VALUES ('Fiction');
INSERT INTO genre (name) VALUES ('Non-Fiction');
INSERT INTO genre (name) VALUES ('Mystery');
INSERT INTO genre (name) VALUES ('Sci-Fi');
INSERT INTO genre (name) VALUES ('Fantasy');

--=========================== insert books ==================================

DROP PROCEDURE InsertBooks

-- Stored Procedure to Insert Books
CREATE PROCEDURE InsertBooks
AS
BEGIN
    DECLARE @i INT = 1;
    DECLARE @j INT = 1;
    DECLARE @bookName VARCHAR(255);
    DECLARE @authorName VARCHAR(255);
    DECLARE @year INT = 2000;
    DECLARE @genreName VARCHAR(50);
    
    WHILE @i <= 5
    BEGIN
        SET @j = 1;
        SET @genreName = (SELECT name FROM genre WHERE name IS NOT NULL ORDER BY NEWID() OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY);
        
        WHILE @j <= 5
        BEGIN
            SET @bookName = 'Book ' + CAST(@j AS VARCHAR) + ' in ' + @genreName;
            SET @authorName = 'Author ' + CAST(@i AS VARCHAR);
            
            INSERT INTO books (book_name, author_name, genre_name, year_published)
            VALUES (@bookName, @authorName, @genreName, @year);
            
            SET @j = @j + 1;
        END;
        
        SET @i = @i + 1;
    END;
END;

-- Execute the stored procedures
EXEC InsertBooks;

--=========================== insert users ==================================
--  connection_status 0 - blocked, 1 - success, 2 - fail
--  user_role  1 - guest user, 2 - connected user, 3 - system manager

INSERT INTO users (email, first_name, last_name, birth_date, pass, connection_status, status_update_time, last_successful_login, user_role)
VALUES ('ranshneor@example.com','Ran','Shneor','1996-01-01','ran123password', 1, '2022-01-01', '2022-01-01', 3);

INSERT INTO users (email, first_name, last_name, birth_date, pass, connection_status, status_update_time, last_successful_login, user_role)
VALUES ('shimon@example.com','Shimon','Levi','1975-08-22','123password', 2, '2022-01-01', '2022-01-01', 2);

INSERT INTO users (email, first_name, last_name, birth_date, pass, connection_status, status_update_time, last_successful_login, user_role)
VALUES ('danit@example.com','Danit','Cohen','1985-03-17','danit123', 2, '2022-01-01', '2022-01-01', 2);

INSERT INTO users (email, first_name, last_name, birth_date, pass, connection_status, status_update_time, last_successful_login, user_role)
VALUES ('avi@example.com','Avi','Ben David','1990-06-02','avipass123', 1, '2022-01-01', '2022-01-01', 2);

INSERT INTO users (email, first_name, last_name, birth_date, pass, connection_status, status_update_time, last_successful_login, user_role)
VALUES ('tal@example.com','Tal','Green','1992-09-08','talpassword', 1, '2022-01-01', '2022-01-01', 1);

INSERT INTO users (email, first_name, last_name, birth_date, pass, connection_status, status_update_time, last_successful_login, user_role)
VALUES ('ori@example.com','Ori','Levi','1988-12-30','oripass1988', 0, '2022-01-01', '2022-01-01', 1);

INSERT INTO users (email, first_name, last_name, birth_date, pass, connection_status, status_update_time, last_successful_login, user_role)
VALUES('noam@example.com', 'Noam', 'Klein', '1990-03-12', 'noam1234', 1, '2022-01-01', '2022-01-01', 2);

INSERT INTO users (email, first_name, last_name, birth_date, pass, connection_status, status_update_time, last_successful_login, user_role)
VALUES ('dana@example.com', 'Dana', 'Levi', '1988-07-13', 'dana5678', 1, '2022-01-01', '2022-01-01', 1);

--=========================== insert restore questions ==================================

INSERT INTO restore_questions (question_number, question)
VALUES (1, 'What was your favorite movie as a child?');

INSERT INTO restore_questions (question_number, question)
VALUES (2, 'What is the name of the elementary school you attended?');

INSERT INTO restore_questions (question_number, question)
VALUES (3, 'What is your all-time favorite food?');

INSERT INTO restore_questions (question_number, question)
VALUES (4, 'What was the name of your first pet?');

INSERT INTO restore_questions (question_number, question)
VALUES(5, 'What city were you born in?');

INSERT INTO restore_questions (question_number, question)
VALUES (6, 'What was your childhood nickname?');

INSERT INTO restore_questions (question_number, question)
VALUES (7, 'What is your mothers maiden name?');

--=========================== insert restore asnwers ==================================

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('ranshneor@example.com','Aladdin',1); 

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('ranshneor@example.com','Ben Zvi',2);

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('ranshneor@example.com','Ice Cream',3);

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('shimon@example.com','Pinocchio',1);

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('shimon@example.com','Bialik',2);

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('shimon@example.com','Pasta',3);

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('danit@example.com','Frozen',1);

INSERT INTO restore_pass (email, answer, question_number)  
VALUES ('danit@example.com','Yad Mordechai',2);

INSERT INTO restore_pass (email, answer, question_number) 
VALUES ('danit@example.com','Hummus',3);

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('avi@example.com','Toy Story',1);

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('avi@example.com','Hayovel',2);

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('avi@example.com','Sushi',3);

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('tal@example.com','Mulan',1);

INSERT INTO restore_pass (email, answer, question_number) 
VALUES ('tal@example.com','Ben Zvi',2);

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('tal@example.com','Ramen',3);

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('ori@example.com','Finding Nemo',1);

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('ori@example.com','HaShalom',2); 

INSERT INTO restore_pass (email, answer, question_number)
VALUES ('ori@example.com','Pasta',3);


--=========================== end of inserting ==================================


--=========================== User Management ==================================

----------------------------- user procedures and triggers ---------------------

DROP TRIGGER if exists LoginAttemptTrg

-- Create the new trigger
CREATE TRIGGER LoginAttemptTrg
ON users
AFTER UPDATE
AS
BEGIN
    IF UPDATE(status_update_time)
    BEGIN
        DECLARE @current_time datetime = CURRENT_TIMESTAMP;

        -- Insert login attempt values into login_log table for the updated user
        INSERT INTO login_log (email, log_time, is_success)
        SELECT i.email, @current_time,
               CASE 
                   WHEN i.connection_status = 1 THEN 1
                   ELSE 0
               END
        FROM Inserted i
        INNER JOIN Deleted d ON i.email = d.email
        WHERE i.status_update_time <> d.status_update_time OR i.connection_status <> d.connection_status;
    END;
END;

--------------------------------------------

-- checking email and password PROCEDURE
DROP PROCEDURE IF EXISTS user_check

CREATE PROCEDURE user_check @user_email varchar(256), @psw nvarchar(256), @result nvarchar(500) OUTPUT
AS
BEGIN
  DECLARE @valid_user int = (SELECT COUNT(*) FROM users WHERE email = @user_email AND pass = @psw);
  DECLARE @attempts int = (SELECT COUNT(*) FROM login_log WHERE email = @user_email  AND DATEDIFF(MINUTE, log_time, GETDATE()) <= 3);
  DECLARE @last_status_time datetime = (SELECT status_update_time FROM users WHERE email = @user_email);
  DECLARE @connect_status int = (SELECT connection_status FROM users WHERE email = @user_email);

  -- Successful login with valid user and less than or equal to 3 attempts
  IF @valid_user = 1 AND @attempts < 3
  BEGIN
    IF @connect_status = 0 AND DATEDIFF(MINUTE, @last_status_time, GETDATE()) > 20
    BEGIN
      SET @result = 'Login Successful - User was previously blocked but is now unblocked after 20 minutes.';
      UPDATE users
      SET connection_status = 1,
          status_update_time = GETDATE(), -- reset the block timer to 20 minutes
          last_successful_login = GETDATE()
      WHERE email = @user_email;
    END
    ELSE IF @connect_status <> 0
    BEGIN
      SET @result = 'Login Successful';
      UPDATE users
      SET connection_status = 1,
          status_update_time = GETDATE(),
          last_successful_login = GETDATE()
      WHERE email = @user_email;
    END
  END
  -- Invalid user or more than 3 attempts
  ELSE
  BEGIN
    IF @attempts > 2
    BEGIN
      SET @result = 'User Blocked - More than 3 login attempts in the last 3 minutes.';
      UPDATE users
      SET connection_status = 0,
          status_update_time = GETDATE()
      WHERE email = @user_email;
    END
    ELSE IF @valid_user = 0 AND @attempts < 3
    BEGIN
      SET @result = 'Login Failed - Invalid username or password, and less than 3 attempts.';
      IF EXISTS (SELECT 1 FROM users WHERE email = @user_email)
      BEGIN
        UPDATE users
        SET connection_status = 2,
            status_update_time = GETDATE()
        WHERE email = @user_email;
      END
      ELSE
      BEGIN
        SET @result = 'Login Failed - Email does not exist.';
      END
    END
  END
END;

-- ===========================================================================

-- shows all login history ALL USERS PROCEDURE
drop PROCEDURE show_my_login_history

CREATE PROCEDURE show_my_login_history @user_email varchar(256)
AS
    BEGIN
        SELECT log_time, is_success
        FROM login_log
        WHERE email = @user_email
    END;

-- =========================================================================== 

/* 1 - guest user, 2 - connected user, 3 - system manager */

---------- CREATE USER AND ANSWER 5 QUESTIONS----------------
drop PROCEDURE create_user

CREATE PROCEDURE create_user
    @user_email VARCHAR(255),
    @first_name VARCHAR(20),
    @last_name VARCHAR(20),
    @birth_date DATE,
    @password VARCHAR(255)
AS
BEGIN
    INSERT INTO users (email, first_name, last_name, birth_date, pass, connection_status,
                       status_update_time, last_successful_login, user_role)
    VALUES (@user_email, @first_name, @last_name, @birth_date, @password, 1,
            GETDATE(), GETDATE(), 1);
END;
-----------------------------

drop PROCEDURE insert_questions

CREATE PROCEDURE insert_questions
(
    @user_email VARCHAR(255),
    @random1 INT,
    @random2 INT,
    @random3 INT,
    @random4 INT,
    @random5 INT,
    @answer1 NVARCHAR(255),
    @answer2 NVARCHAR(255),
    @answer3 NVARCHAR(255),
    @answer4 NVARCHAR(255),
    @answer5 NVARCHAR(255)
)
AS
BEGIN
    -- Insert records into restore_pass table
    INSERT INTO restore_pass (email, question_number, answer)
    VALUES (@user_email, @random1, @answer1),
           (@user_email, @random2, @answer2),
           (@user_email, @random3, @answer3),
           (@user_email, @random4, @answer4),
           (@user_email, @random5, @answer5);
    
    -- Update user_role in the users table
    UPDATE users
    SET user_role = 2
    WHERE email = @user_email;
END;

-- =========================================================================== 

----------RESET PASSWORD BASED ON ANSWERS FOR QUESTIONS----------------

drop PROCEDURE get_random_questions

CREATE PROCEDURE get_random_questions
  @user_email varchar(256)
AS
BEGIN
  DECLARE @randomQuestions TABLE (
    questionNumber int,
    questionText varchar(256)
  )
  
  INSERT INTO @randomQuestions (questionNumber, questionText)
  SELECT TOP 3 rp.question_number, rq.question
  FROM restore_pass rp
  INNER JOIN restore_questions rq ON rp.question_number = rq.question_number
  WHERE rp.email = @user_email
  ORDER BY NEWID()
  
  SELECT questionNumber, questionText FROM @randomQuestions
END

------ validate answers
drop PROCEDURE validate_answers

CREATE PROCEDURE validate_answers
  @user_email varchar(256),
  @answer1 nvarchar(256),
  @answer2 nvarchar(256),
  @answer3 nvarchar(256),
  @question1 int,
  @question2 int,
  @question3 int,
  @isCorrect bit OUTPUT
AS  
BEGIN
  DECLARE @correctAnswers int = 0

  -- Check the first answer
  IF EXISTS (
    SELECT * 
    FROM restore_pass
    WHERE email = @user_email
    AND question_number = @question1
    AND answer = @answer1
  )
  BEGIN
    SET @correctAnswers = @correctAnswers + 1
  END

  -- Check the second answer
  IF EXISTS (
    SELECT * 
    FROM restore_pass
    WHERE email = @user_email
    AND question_number = @question2
    AND answer = @answer2
  )
  BEGIN
    SET @correctAnswers = @correctAnswers + 1
  END

  -- Check the third answer
  IF EXISTS (
    SELECT * 
    FROM restore_pass
    WHERE email = @user_email
    AND question_number = @question3
    AND answer = @answer3
  )
  BEGIN
    SET @correctAnswers = @correctAnswers + 1
  END

  -- If at least 3 answers are correct, set the output flag to true
  SET @isCorrect = CASE 
    WHEN @correctAnswers >= 3 THEN 1
    ELSE 0
  END
END
-------------------

drop PROCEDURE reset_user_password

CREATE PROCEDURE reset_user_password
  @user_email varchar(256),
  @newPassword nvarchar(256)
AS  
BEGIN
  UPDATE users
  SET pass = @newPassword
  WHERE email = @user_email
  PRINT 'Password reset successfully'
END

-- ===========================================================================
---------------------------------------------------------------------------------
---------------------------------------------------------------------------------
---------------------------------------------------------------------------------
---------------------------------------------------------------------------------
------------------------ admin procedures and triggers --------------------------

-- shows all blocked users in last 20 minutes ADMIN PROCEDURE
drop procedure show_blocked_users

create procedure show_blocked_users @admin_email varchar(256)
as
	declare @user tinyint = (select user_role
							from users
							where email = @admin_email)
	if @user = 3
		begin
			select distinct U.email
			from users as U
			where U.connection_status=0 and DATEDIFF(MINUTE,CURRENT_TIMESTAMP,U.status_update_time) < 20
		end
	else
		begin
			print 'You do not have permissions for that action'
		end	

----------------------------------------------
-- Shows for every user it's last successful login ADMIN PROCEDURE

drop  procedure show_successful_login

create procedure show_successful_login @admin_email varchar(256)
as
	declare @user tinyint = (select top 1 user_role
							from users
							where email = @admin_email
							order by last_successful_login desc)
	if @user = 3
		begin
			select U.email, U.last_successful_login
			from users as U
		end
	else
		begin
			print 'You do not have permissions'
		end	


--===================================================================================
--===================================================================================
--===================================================================================
--===================================================================================
--===================================================================================
--===================================================================================
--===================================================================================
--===================================================================================
--===================================================================================


-- =============================== LIBRARY PROJECT ==================================

drop procedure LoanABook

CREATE PROCEDURE LoanABook
    @book_id INT,
    @user_email VARCHAR(255)
AS
BEGIN
    DECLARE @loan_date smalldatetime = CURRENT_TIMESTAMP;
    DECLARE @return_date smalldatetime = DATEADD(DAY, 14, @loan_date);
    BEGIN TRAN
    SAVE TRANSACTION BeforeLoan;

    BEGIN TRY
        -- Step 1: Check if the book exists and is not already loaned
        IF NOT EXISTS (SELECT 1 FROM books WHERE book_id = @book_id)
        BEGIN
            THROW 50000, 'The book does not exist.', 1;
        END

        IF EXISTS (SELECT 1 FROM loan_log WHERE book_id = @book_id AND is_returned = 0)
        BEGIN
            THROW 50001, 'The book is already loaned.', 1;
        END

        -- Step 2: Insert into the loan_log
        INSERT INTO loan_log (book_id, email, loan_date, loan_return_date)
        VALUES (@book_id, @user_email, @loan_date, @return_date);

        -- If all steps are successful, commit the transaction
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION BeforeLoan;
        THROW;
    END CATCH;
END;

------
drop PROCEDURE ReturnABook

CREATE PROCEDURE ReturnABook
    @book_id INT,
    @user_email VARCHAR(255)
AS
BEGIN
    DECLARE @current_date smalldatetime = CURRENT_TIMESTAMP;
    BEGIN TRAN
    SAVE TRANSACTION BeforeReturn;

    BEGIN TRY
        -- Step 1: Check if the loan exists and hasn't been returned yet
        IF NOT EXISTS (SELECT 1 FROM loan_log 
                       WHERE book_id = @book_id AND email = @user_email AND is_returned = 0)
        BEGIN
            THROW 51000, 'The loan does not exist or has already been returned.', 1;
        END
        
        -- Step 2: Update the loan_log to set the return date and mark as returned
        UPDATE loan_log
        SET loan_return_date = @current_date, is_returned = 1
        WHERE book_id = @book_id AND email = @user_email;

        -- If all steps are successful, commit the transaction
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION BeforeReturn;
        THROW;
    END CATCH;
END;

-----

drop PROCEDURE ShowLoanedBooks

CREATE PROCEDURE ShowLoanedBooks
    @user_email VARCHAR(255)
AS
BEGIN
    -- Select all loaned books for the given user
    SELECT 
        b.book_id,
        b.book_name,
        b.author_name,
        l.loan_date,
        l.loan_return_date,
		l.is_returned
    FROM loan_log AS l
    JOIN books AS b ON l.book_id = b.book_id
    WHERE l.email = @user_email;
END;

--------------
drop view UserLoanedBooks

CREATE VIEW UserLoanedBooks AS
SELECT l.email, b.book_id, b.book_name, b.author_name, l.loan_date, l.loan_return_date, l.is_returned
FROM loan_log l
JOIN books b ON l.book_id = b.book_id
WHERE l.is_returned = 0;


---------------------------------------------------------------------------------
---------------------------------------------------------------------------------
---------------------------------------------------------------------------------
---------------------------------------------------------------------------------
------------------------ admin procedures and triggers --------------------------

drop PROCEDURE RemoveABook

CREATE PROCEDURE RemoveABook
    @book_id INT,
    @admin_email VARCHAR(255)
AS
BEGIN
    -- Check if the email belongs to an admin
    IF NOT EXISTS (SELECT 1 FROM users WHERE email = @admin_email AND user_role = 3)
    BEGIN
        THROW 51000, 'You do not have permission to remove a book.', 1;
        RETURN;
    END

    -- Check if the book exists
    IF NOT EXISTS (SELECT 1 FROM books WHERE book_id = @book_id)
    BEGIN
        THROW 51000, 'The book you are trying to remove does not exist.', 1;
        RETURN;
    END

    -- Check if the book is currently loaned
    IF EXISTS (SELECT 1 FROM loan_log WHERE book_id = @book_id)
    BEGIN
        THROW 51000, 'The book is currently loaned and cannot be removed.', 1;
        RETURN;
    END

    -- Start the transaction
    BEGIN TRAN

    -- Savepoint before attempting to remove the book
    SAVE TRANSACTION BeforeRemove;

    BEGIN TRY
        -- Remove the book from the books table
        DELETE FROM books WHERE book_id = @book_id;

        -- If successful, commit the transaction
        COMMIT;
    END TRY
    BEGIN CATCH
        -- If an error occurs, rollback to the savepoint
        ROLLBACK TRANSACTION BeforeRemove;

        -- Re-throw the error for debugging
        THROW;
    END CATCH;
END;
---------------------------------

-- add book

drop PROCEDURE AddABook

CREATE PROCEDURE AddABook
    @book_name VARCHAR(255),
    @author_name VARCHAR(255),
    @genre_name VARCHAR(50),
    @year_published INT,
    @admin_email VARCHAR(255)
AS
BEGIN
    -- Check if the email belongs to an admin
    IF NOT EXISTS (SELECT 1 FROM users WHERE email = @admin_email AND user_role = 3)
    BEGIN
        THROW 51000, 'You do not have permission to add a book.', 1;
        RETURN;
    END

    -- Insert the new book into the books table
    INSERT INTO books (book_name, author_name, genre_name, year_published)
    VALUES (@book_name, @author_name, @genre_name, @year_published);
END;

--------------------------------------

-- remove user

drop PROCEDURE RemoveAUser

CREATE PROCEDURE RemoveAUser
    @user_email VARCHAR(255),
    @admin_email VARCHAR(255)
AS
BEGIN
    -- Start the transaction
    BEGIN TRAN;

    -- Savepoint before attempting to remove a user
    SAVE TRANSACTION BeforeRemovingUser;

    BEGIN TRY
        -- Step 1: Check if the admin is performing the action
        IF NOT EXISTS (SELECT 1 FROM users WHERE email = @admin_email AND user_role = 3)
        BEGIN
            THROW 51000, 'Only an admin can remove a user.', 1;
        END

        -- Step 2: Check if the user exists
        IF NOT EXISTS (SELECT 1 FROM users WHERE email = @user_email)
        BEGIN
            THROW 51000, 'User does not exist.', 1;
        END

        -- Step 3: Check if the user has any loaned books
        IF EXISTS (SELECT 1 FROM loan_log WHERE email = @user_email AND is_returned = 0)
        BEGIN
            THROW 51000, 'User has loaned books and cannot be removed.', 1;
        END

        -- Step 4: Check if the user is an admin
        IF EXISTS (SELECT 1 FROM users WHERE email = @user_email AND user_role = 3)
        BEGIN
            THROW 51000, 'The user you are trying to remove is an administrator.', 1;
        END

        -- Step 5: Remove the user from tables
        DELETE FROM loan_log WHERE email = @user_email;
		DELETE FROM restore_pass where email = @user_email;
        DELETE FROM users WHERE email = @user_email;

        -- Commit the transaction if all steps are successful
        COMMIT;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if an error occurs
        ROLLBACK TRANSACTION BeforeRemovingUser;

        -- Re-throw the error for debugging
        THROW;
    END CATCH;
END;

------------------------------------------

CREATE PROCEDURE show_all_users
AS
BEGIN
    SELECT * FROM users;
END;

------------------------------------------

CREATE PROCEDURE show_all_books
AS
BEGIN
    SELECT * FROM books;
END;

------------------------------------------

-- Trigger for inserting new loan logs
CREATE TRIGGER UpdateIsLoanedOnLoanLogInsert
ON loan_log
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE books
    SET is_loaned = 1
    WHERE book_id IN (SELECT book_id FROM inserted);
END;

------------------------------------------

-- Trigger for updating loan logs
CREATE TRIGGER UpdateIsLoanedOnLoanLogUpdate
ON loan_log
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE books
    SET is_loaned = CASE 
                       WHEN i.is_returned = 1 THEN 0
                       ELSE 1
                   END
    FROM inserted i
    WHERE books.book_id = i.book_id;
END;

-----------------------------------------

DROP PROCEDURE IF EXISTS  GetBooksOfMostLoanedAuthor_PerUser

CREATE PROCEDURE GetBooksOfMostLoanedAuthor_PerUser
    @TargetMonth INT,
    @TargetYear INT,
    @user_email VARCHAR(255)
AS
BEGIN
    -- Create a temporary table to store the most loaned author
    CREATE TABLE #MostLoanedAuthor (
        AuthorName VARCHAR(255)
    );

    -- Insert the most loaned author by the user for the given month and year into the temp table
    INSERT INTO #MostLoanedAuthor (AuthorName)
    SELECT TOP 1 b.author_name
    FROM loan_log l
    JOIN books b ON l.book_id = b.book_id
    WHERE MONTH(l.loan_date) = @TargetMonth AND YEAR(l.loan_date) = @TargetYear AND l.email = @user_email
    GROUP BY b.author_name
    ORDER BY COUNT(*) DESC;

    -- Check if we have any data
    IF EXISTS (SELECT 1 FROM #MostLoanedAuthor)
    BEGIN
        -- Return the user's details and the list of books they've loaned from the most loaned author
        SELECT u.first_name, u.last_name, b.book_name, b.author_name
        FROM loan_log l
        JOIN books b ON l.book_id = b.book_id
        JOIN users u ON l.email = u.email
        JOIN #MostLoanedAuthor m ON b.author_name = m.AuthorName
        WHERE l.email = @user_email AND MONTH(l.loan_date) = @TargetMonth AND YEAR(l.loan_date) = @TargetYear;
    END
    ELSE
    BEGIN
        SELECT 'No data found' AS Message;
    END

    -- Drop the temporary table
    DROP TABLE #MostLoanedAuthor;
END;

---------------
DROP PROCEDURE IF EXISTS  GetBooksOfMostLoanedGenre_PerUser

CREATE PROCEDURE GetBooksOfMostLoanedGenre_PerUser
    @TargetMonth INT,
    @TargetYear INT,
    @user_email VARCHAR(255)
AS
BEGIN
    -- Create a temporary table to store the most loaned author
    CREATE TABLE #MostLoanedGenre (
        GenreName VARCHAR(255)
    );

    -- Insert the most loaned author by the user for the given month and year into the temp table
    INSERT INTO #MostLoanedGenre (GenreName)
    SELECT TOP 1 b.genre_name
    FROM loan_log l
    JOIN books b ON l.book_id = b.book_id
    WHERE MONTH(l.loan_date) = @TargetMonth AND YEAR(l.loan_date) = @TargetYear AND l.email = @user_email
    GROUP BY b.genre_name
    ORDER BY COUNT(*) DESC;

    -- Check if we have any data
    IF EXISTS (SELECT 1 FROM #MostLoanedGenre)
    BEGIN
        -- Return the user's details and the list of books they've loaned from the most loaned genre
        SELECT u.first_name, u.last_name, b.book_name, b.genre_name
        FROM loan_log l
        JOIN books b ON l.book_id = b.book_id
        JOIN users u ON l.email = u.email
        JOIN #MostLoanedGenre m ON b.genre_name = m.GenreName
        WHERE l.email = @user_email AND MONTH(l.loan_date) = @TargetMonth AND YEAR(l.loan_date) = @TargetYear;
    END
    ELSE
    BEGIN
        SELECT 'No data found' AS Message;
    END

    -- Drop the temporary table
    DROP TABLE #MostLoanedGenre;
END;

------------------------------

CREATE VIEW CurrentlyLoanedBooks AS
SELECT b.book_id, b.book_name, b.author_name, u.first_name, u.last_name
FROM loan_log l JOIN books b ON l.book_id = b.book_id
				JOIN users u ON l.email = u.email
WHERE l.is_returned = 0;

------

CREATE VIEW UserLoginHistory AS
SELECT l.email, l.log_time, l.is_success
FROM login_log l;

---------------------

DROP PROCEDURE AdminPermissionsLoop

CREATE PROCEDURE AdminPermissionsLoop
AS
BEGIN
    -- Declare variables
    DECLARE @adminMail NVARCHAR(255);
    DECLARE @adminPass NVARCHAR(255);
    DECLARE @tableName NVARCHAR(255);
    DECLARE @sql NVARCHAR(MAX);

    -- Create temporary tables
    CREATE TABLE #AdminUsers (admin_mail NVARCHAR(255), adminPass NVARCHAR(255));
    CREATE TABLE #TableNames (tableName NVARCHAR(255));

    -- Populate temporary tables
    INSERT INTO #AdminUsers (admin_mail, adminPass)
    SELECT email, pass
    FROM users
    WHERE user_role = 3;

    INSERT INTO #TableNames (tableName)
    VALUES ('books'), ('loan_log'), ('login_log'), ('restore_pass'), ('users');

    -- Declare cursors
    DECLARE admin_cursor CURSOR FOR SELECT admin_mail, adminPass FROM #AdminUsers;
    DECLARE table_cursor CURSOR FOR SELECT tableName FROM #TableNames;

    -- Open admin cursor and loop through all admins
    OPEN admin_cursor;
    FETCH NEXT FROM admin_cursor INTO @adminMail, @adminPass;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Create SQL Server login if not exists
        SET @sql = 'IF NOT EXISTS (SELECT name FROM sys.sql_logins WHERE name = ''' + @adminMail + ''') ' +
                   'CREATE LOGIN [' + @adminMail + '] WITH PASSWORD = ''' + @adminPass + ''', CHECK_POLICY = OFF;';
        EXEC sp_executesql @sql;

        -- Create database user for this login
        SET @sql = 'IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = ''' + @adminMail + ''') ' +
                   'CREATE USER [' + @adminMail + '] FOR LOGIN [' + @adminMail + '];';
        EXEC sp_executesql @sql;

        -- Open table cursor and loop through all table names
        OPEN table_cursor;
        FETCH NEXT FROM table_cursor INTO @tableName;
        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Grant permissions to admin for this table
            SET @sql = 'GRANT SELECT, INSERT, UPDATE, DELETE ON ' + @tableName + ' TO [' + @adminMail + '];';
            EXEC sp_executesql @sql;

            FETCH NEXT FROM table_cursor INTO @tableName;
        END

        CLOSE table_cursor;

        FETCH NEXT FROM admin_cursor INTO @adminMail, @adminPass;
    END

    CLOSE admin_cursor;

    DEALLOCATE admin_cursor;
    DEALLOCATE table_cursor;

    DROP TABLE #AdminUsers;
    DROP TABLE #TableNames;
END;