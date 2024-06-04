import User from '../models/User.js';

export const createUser = async (rq,rs) => {
    rq.body.admin = false;
    await new User(rq.body).save()
    .then((user) => {
        console.log(user);
        rs.status(201).json({code:201, msg: "Created user:", user: user});
    })
    .catch((error) => {
        console.log(error);
        if (error.code == 11000) 
            return rs.status(500).json({code:500, msg: "Email is already used"});
        rs.status(500).json({code:500, msg: "Unable to create user"});
    });
}

export const getUsers = async(rq,rs) => {
    await User.find()
    .then((users) => {

        if(!users.length) throw new Error('err');
        console.log(users);
        rs.status(200).json({code:200, msg: "Found " + users.length + " users", users: users});
    })
    .catch((error) => {
        console.log(error);
        rs.status(500).json({code:500, msg: "Unable to find any users"});
    });
}