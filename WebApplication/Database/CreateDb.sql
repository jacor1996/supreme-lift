--CREATE DATABASE SupremeLiftDb

/*
GO
CREATE TABLE [User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(MAX) NOT NULL,
	[Age] INT NOT NULL,
	[Weight] FLOAT NOT NULL,
	[Height] FLOAT NOT NULL,
	[Sex] INT NOT NULL
)
*/

/*
GO
CREATE TABLE [Exercise]
(
	[ExerciseId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(MAX) NOT NULL,
	[CaloriesBurned] FLOAT NOT NULL
)
*/

/*
GO
CREATE TABLE [Workout]
(
	[WorkoutId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Fk_UserId] INT FOREIGN KEY REFERENCES [User](UserId)
)
*/

/*
GO
CREATE TABLE [WorkoutExercise]
(
	[WorkoutExerciseId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Sets] INT NOT NULL,
	[Reps] INT NOT NULL,
	[Fk_ExerciseId] INT FOREIGN KEY REFERENCES [Exercise](ExerciseId),
	[Fk_WorkoutId] INT FOREIGN KEY REFERENCES [Workout](WorkoutId)
)
*/
/*
CREATE TABLE [Record]
(
	[RecordId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[WeightLifted] FLOAT NOT NULL,
	[Fk_ExerciseId] INT FOREIGN KEY REFERENCES [Exercise](ExerciseId),
	[Fk_UserId] INT FOREIGN KEY REFERENCES [User](UserId)
)
*/