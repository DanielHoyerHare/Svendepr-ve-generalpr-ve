import {login, createUser} from '../controllers/Users.js'
import express from 'express';

const router = express.Router();

router.get('/:id/:hashedPass', login);
router.post('/', createUser);

export default router;