import {getUsers, createUser} from '../controllers/Users.js'
import {authenticate} from '../middlewares/Authenticator.js';
import express from 'express';

const router = express.Router();

router.post('/', authenticate, createUser);
router.get('/', authenticate, getUsers);

export default router;