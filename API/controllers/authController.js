import jwt from 'jsonwebtoken';
import User from '../models/user.js'
import Goal from '../models/goal.js'

export const register = async (rq,rs) => {
    rq.body.admin = false;
    await new User(rq.body).save()
    .then((user) => {
        console.log(user);
        const token = jwt.sign({ userId: user._id }, process.env.SECRET_KEY, {
            expiresIn: '1 hour'
        });
        const goal = new Goal({
            userId: user._id
        })
        goal.save();
        rs.status(201).json({ token });
    })
    .catch((error) => {
        console.log(error);
        if (error.code == 11000) 
            return rs.status(500).json({code:500, msg: 'Username or email is already used'});
        rs.status(500).json({code:500, msg: 'Unable to create user'});
    });
}

export const login = async(rq,rs) => {
    let searcher = {email: rq.body.email}
    if (!rq.body.email) searcher = {username: rq.body.username}
    await User.findOne(searcher)
    .then((user) => {
        if (!user) throw new Error('err');
        const passwordMatch = user.comparePassword(rq.body.password);
        if (!passwordMatch) return rs.status(401).json({code:401, msg: 'Wrong password'});
        const token = jwt.sign({ userId: user._id }, process.env.SECRET_KEY, {
            expiresIn: '1 hour'
        });
        rs.status(201).json({ token });
    })
    .catch((error) => {
        console.log(error);
        rs.status(500).json({code:500, msg: 'Unable to find user'});
    });
}