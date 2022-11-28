# intro_to_api_final_project_imtiaz
api for making goals

API Routes!<br />
Get Method:<br />
/Goals
This displays all the current goals that have been made in the past.

/Goals/id?id=2
This displays the specific goal associated with the given id. If the id is not found a 404 error will be returned with a message.


Post Method:
/createGoal
This allows the user to add a new goal while inputting method associated to the goal. The api handles updating the new data on all three tables (Goals, methods, users) after receiving the values to every field.

Put Method:
/Goals/{id}
This allows you to update any parts of an existing goal such as completed status. If the goal is not found in the database or there is a mismatch between the goal_id in the body and parameter a 400 error related to BadRequest will be returned, else if it works a 204 Accepted will be returned.

Database:
It contains three tables called goals, methods, and users. Goals has a primary key of goals_id and a foreign key of method_id. The methods table has a primary key of method_id. Finally, the users table has a foreign key of goals_id to associate users to their connected goals.

