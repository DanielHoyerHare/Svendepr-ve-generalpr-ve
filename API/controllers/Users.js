import User from '../models/User.js'

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

export const login = async(rq,rs) => {
    await User.findById(rq.params.id)
    .then((user) => {
        if (!user) throw new Error('err');
        if (user.password != rq.params.hashedPass) return rs.status(401).json({code:401, msg: "Wrong password"});
        user.password = null;
        rs.status(200).json({code:200, msg: "Login was successful", user: user});
    })
    .catch((error) => {
        console.log(error);
        rs.status(500).json({code:500, msg: "Unable to find the contact"});
    });
}