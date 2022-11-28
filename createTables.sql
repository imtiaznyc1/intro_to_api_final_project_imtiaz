CREATE SCHEMA `EndlessMilestones`;

CREATE TABLE EndlessMilestones.goals (
	goals_id INT PRIMARY KEY,
    goal_title VARCHAR (50) NOT NULL,
    goal_desc VARCHAR (500) NOT NULL,
    deadline DATETIME,
    completed BOOLEAN DEFAULT false
);


CREATE TABLE EndlessMilestones.users (
    	user_id INT,
        first_name VARCHAR (50) NOT NULL,
        last_name VARCHAR (50) NOT NULL,
        age INT,
        goals_id INT NOT NULL,
        FOREIGN KEY (goals_id) REFERENCES EndlessMilestones.goals (goals_id)
);


CREATE TABLE EndlessMilestones.methods (
	method_id INT PRIMARY KEY,
    method_descp VARCHAR (500) NOT NULL
);


ALTER TABLE EndlessMilestones.goals
ADD method_id INT NOT NULL;


ALTER TABLE EndlessMilestones.goals
ADD FOREIGN KEY (method_id) REFERENCES EndlessMilestones.methods(method_id);
