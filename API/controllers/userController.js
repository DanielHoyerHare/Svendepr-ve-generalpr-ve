import { authenticate } from "../middlewares/Authenticator.js"
import { User } from "../models/user.js"

export const getUsers = async (req, res) => {
    console.log(authenticate());
    await User.find()
    .then((users) => {
        res.status(200).json({users: users})
    })
    .catch((error) => {
        console.log(error)
        res.status(500).json({msg: "unable to get users"})
    })
    
}

export const getUser = async (req, res) => {
    try {
        const id = req.params.id
        User.findById(id)
        .then((users) => {
            res.status(200).json({user: users})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to get user"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get user"})
    }
};

export const search = async (req, res) => {
    try {
        const searchTerm = req.query.searchTerm
        
        const searchRegex = new RegExp(searchTerm, "i")
        
        await User.find({
            $or : [
                {rolle: searchRegex},
                {usersame: searchRegex},
                {email: searchRegex},
                {password: searchRegex},
                {alder: searchRegex},
                {vægt: searchRegex},
                {højde: searchRegex},
            ]
        })
        .then((users) => {
            if(users.lenght){
                console.log(users)
                res.status(200).json({users: users})
            }
            else{
                res.status(200).json({users: [], msg: "no users found"})
            }
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to find user"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get user"})
    }
};

export const createUser = async (req, res) => {
    const user = new User(req.body)
    await user.save()
    .then((savedUsers) => {
        console.log(savedUsers)
        res.status(201).json({msg: 'user saved', user})
    })
    .catch ((error) => {
        console.log(error)
        res.status(500).json({msg: 'unable to create new user', user})
    })
}

export const deleteUser = async (req, res) => {
    try {
        const id = req.params.id

        await User.findByIdAndDelete(id)
        .then((users) => {
            res.status(200).json({msg: "Following user has been deleted", user: users})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to get user"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get user"})
    }
}

export const updateUser = async (req, res) => {
    try {
        const id = req.params.id
        const updatedUser = req.body

        await User.findOneAndUpdate({_id: id}, updatedUser, {new: true})
        .then((updatedUser) => {
            console.log(updatedUser)
            res.status(200).json({msg: "user updated", user: updatedUser})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to update user"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to update user"})
    }
}