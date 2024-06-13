import express from 'express'
import { authenticate } from '../middlewares/Authenticator.js';
import { 
    getUsers, 
    getUser, 
    search, 
    createUser, 
    deleteUser, 
    updateUser } from '../controllers/userController.js'

const router = express.Router();

router.get('/', authenticate, getUsers);
router.get('/:id', authenticate, getUser)
router.get('/search', authenticate, search)
router.post('/', authenticate, createUser)
router.delete('/:id', authenticate, deleteUser)
router.put('/:id', authenticate, updateUser)

export default router;