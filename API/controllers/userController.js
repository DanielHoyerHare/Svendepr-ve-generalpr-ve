import User from "../models/user.js"

export const getUsers = async (rq, rs) => {
    if (!rq.user.admin) return rs.status(401).json({ message: 'No access' });
    await User.find()
    .then((users) => {
        rs.status(200).json({users: users})
    })
    .catch((error) => {
        console.log(error)
        rs.status(500).json({msg: "unable to get users"})
    })
    
}

export const getUser = async (rq, rs) => {
    const id = rq.params.id
    if (!(rq.user.admin || rq.user.id == id)) return rs.status(401).json({ message: 'No access' });
    User.findById(id)
    .then((users) => {
        rs.status(200).json({user: users})
    })
    .catch((error) => {
        console.log(error)
        rs.status(500).json({msg: "unable to get user"})
    })
};

export const search = async (rq, rs) => {
    if (!rq.user.admin) return rs.status(401).json({ message: 'No access' });
    const searchTerm = rq.query.searchTerm
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
            rs.status(200).json({users: users})
        }
        else{
            rs.status(200).json({users: [], msg: "no users found"})
        }
    })
    .catch((error) => {
        console.log(error)
        rs.status(500).json({msg: "unable to find user"})
    });
};

export const createUser = async (rq, rs) => {
    if (!rq.user.admin) return rs.status(401).json({ message: 'No access' });
    await new User(rq.body).save()
    .then((user) => {
        rs.status(201).json({msg: 'user saved', user})
    })
    .catch ((error) => {
        console.log(error)
        rs.status(500).json({msg: 'unable to create new user'})
    })
}

export const deleteUser = async (rq, rs) => {
    const id = rq.params.id
    if (!(rq.user.admin || rq.user.id == id)) return rs.status(401).json({ message: 'No access' });

    await User.findByIdAndDelete(id)
    .then((users) => {
        rs.status(200).json({msg: "Following user has been deleted", user: users})
    })
    .catch((error) => {
        console.log(error)
        rs.status(500).json({msg: "unable to get user"})
    })
}

export const updateUser = async (rq, rs) => {

    const id = rq.params.id
    if (!(rq.user.admin || rq.user.id == id)) return rs.status(401).json({ message: 'No access' });
    
    await User.findOneAndUpdate({_id: id}, rq.body, {new: true, runValidators: true})
    .then((updatedUser) => {
        rs.status(200).json({msg: "user updated", user: updatedUser})
    })
    .catch((error) => {
        console.log(error)
        rs.status(500).json({msg: "unable to update user"})
    });
}