import jwt from 'jsonwebtoken';
import User from '../models/User.js';

export const authenticate = async (rq, rs, next) => {
  const token = rq.headers.authorization?.split(' ')[1];

  if (!token) {
    return rs.status(401).json({ message: 'Authentication required' });
  }

  try {
    const decodedToken = jwt.verify(token, process.env.SECRET_KEY);
    const user = await User.findById(decodedToken.userId);
    if (!user) {
      return rs.status(404).json({ message: 'User not found' });
    }

    rq.user = user;
    next();
  } catch (err) {
    rs.status(401).json({ message: 'Invalid token' });
  }
};