# intro_to_api_final_project_imtiaz

**Description:**<br />
This API called "EndlessMilestones" was created to allow users to store and track various long term goals they may have. At times we set things that we want to accomplish only to forget about them after a certain amount of time. <br />

**API Routes!**<br />
**Get Method:**<br />
/Goals<br />
This displays all the current goals that have been made in the past.<br /><br />

/Goals/id?id=2<br />
This displays the specific goal associated with the given id. If the id is not found a 404 error will be returned with a message.<br /><br />


**Post Method:**<br />
/createGoal<br />
This allows the user to add a new goal while inputting method associated to the goal. The api handles updating the new data on all three tables (Goals, methods, users) after receiving the values to every field.<br /><br />

**Put Method:**<br />
/Goals/{id}<br />
This allows you to update any parts of an existing goal such as completed status. If the goal is not found in the database or there is a mismatch between the goal_id in the body and parameter a 400 error related to BadRequest will be returned, else if it works a 204 Accepted will be returned.<br /><br />

**Database:**<br />
It contains three tables called goals, methods, and users. Goals has a primary key of goals_id and a foreign key of method_id. The methods table has a primary key of method_id. Finally, the users table has a foreign key of goals_id to associate users to their connected goals.<br />

