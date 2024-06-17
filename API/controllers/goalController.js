// importing goal model
import Goal from "../models/goal.js"

// exporting get all method
export const getGoals = async (req, res) => {
    // if user is admin all users goals will be returned 
    if (req.user.admin)
    {
        Goal.find().sort({startDate: -1}).populate('user')
        .then((goals) => {
            // returns status 200 and all users goals
            res.status(200).json({goals: goals})
        })
        .catch((error) => {
            // logs and return status 500 error if failed
            console.log(error)
            res.status(500).json({msg: "unable to get goals"})
        });
    }
    // if user is not admin - only the users goals will be returned
    else 
    {
        Goal.find({user: req.user.id}).sort({startDate: -1})
        .then((goals) => {
            // returns status 200 and all goals
            res.status(200).json({goals: goals})
        })
        .catch((error) => {
            // logs and return status 500 error if failed
            console.log(error)
            res.status(500).json({msg: "unable to get goals"})
        });
    }
}

// exporting get method - gets specific goal for one user through userId
export const getGoal = async (req, res) => {
    // gets user id from request params
    const userId = req.params.userId

    // if the user isn't admin or no userId is found -> error returns
    if (!(req.user.admin || req.user.id == userId)) 
        return res.status(401).json({ message: 'No access' });

    // finds goal through userId and sort it to the latest goal
    Goal.findOne({user: userId}).sort({startDate: -1})
    .then((goal) => {
        // returns status 200 and the users last goal
        res.status(200).json({goal: goal})
    })
    .catch((error) => {
        // logs and returns status 500 error if failed or no goals found
        console.log(error)
        res.status(500).json({msg: "unable to get goal"})
    })
};

// exporting search method - gets goals that match certain criterias
export const search = async (req, res) => {
    // gets user id from request params
    const userId = req.params.userId

    // if the user isn't admin or no userId is found -> error returns
    if (!(req.user.admin || req.user.id == userId)) 
        return res.status(401).json({ message: 'No access' });

    try {
        // creates search term from the request query
        const searchTerm = req.query.searchTerm
        
        // creates regex for search
        const searchRegex = new RegExp(searchTerm, "i")
        
        // specifies criterias to search for
        await Goal.find({
            $or : [
                {startDate: searchRegex},
                {calorieGoal: searchRegex},
                {fatgoal: searchRegex},
                {carbonhydratesGoal: searchRegex}
            ]
        })
        .then((goals) => {
            if(goals.lenght){
                // logs and returns the goals that match
                console.log(goals)
                res.status(200).json({goals: goals})
            }
            else{
                // returns nothing if no goals match
                res.status(200).json({goals: [], msg: "no goals found"})
            }
        })
    } catch (error) {
        // logs and returns status 500 if error
        console.log(error)
        res.status(500).json({msg: "unable to get goal"})
    }
};

// exporting create method - creates new goal
export const createGoal = async (req, res) => {
    if (req.body.user == null) 
        req.body.user = req.user.id;

    // if the user isn't admin or no userId is found -> error returns
    if (!(req.user.admin || req.user.id == req.body.user)) 
        return res.status(401).json({ message: 'No access' });

    // sets startDate to the date of creation
    req.body.startDate = new Date().getTime();

    // saves the new goal to database
    await new Goal(req.body).save()
    .then((goal) => {
        // returns the created goal
        res.status(201).json({msg: 'goal saved', goal})
    })
    .catch ((error) => {
        // logs and returns status 500 if error -> goal not created
        console.log(error)
        res.status(500).json({msg: 'unable to create new goal'})
    })
}

// exporting delete method - deletes a goal through id
export const deleteGoal = async (req, res) => {
    // gets user id from request params
    const userId = req.params.userId

    // if the user isn't admin or userId isn't matching error returns
    if (!(req.user.admin || req.user.id == userId)){
        return res.status(401).json({ message: 'No access' });
    }

    try {
        // gets id from params
        const id = req.params.id

        // deletes the food from database
        await Goal.findByIdAndDelete(id)
        .then((goals) => {
            // returns the deleted goal
            res.status(200).json({msg: "Following goal has been deleted", 
                goal: goals})
        })
    } catch (error) {
        // logs and returns status 500 if error 
        // goal not deleted or couldn't be found
        console.log(error)
        res.status(500).json({msg: "unable to delete goal"})
    }
}

// exporting update method - updates a goal through id
export const updateGoal = async (req, res) => {
    // gets user id from request params
    const userId = req.params.userId

    // if the user isn't admin or no userId is found -> error returns
    if (!(req.user.admin || req.user.id == userId)) {
        return res.status(401).json({ message: 'No access' });
    }
    
    try {
        // gets id from params
        const id = req.params.id
        
        // sets new goal with body
        const updatedGoal = req.body
        rq.body.startDate = new Date().getTime();

        // updates the goal in database
        await Goal.findOneAndUpdate({_id: id}, updatedGoal, {new: true})
        .then((updatedGoal) => {
            // logs and returns the updated goal
            console.log(updatedGoal)
            res.status(200).json({msg: "goal updated", 
                goal: updatedGoal})
        })
    } catch (error) {
        // logs and returns status 500 if error 
        // goal couldn't be found or couldn't be updated
        console.log(error)
        res.status(500).json({msg: "unable to update goal"})
    }
}