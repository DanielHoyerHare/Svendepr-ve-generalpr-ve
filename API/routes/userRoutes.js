import express from 'express'
import { getUsers, getUser, search, createUser, deleteUser, updateUser } from '../controllers/userController.js'

const router = express.Router();

router.get('/', getUsers);
router.get('/search/:id', getUser)
router.get('/search', search)
router.post('/', createUser)
router.delete('/:id', deleteUser)
router.put('/:id', updateUser)

export default router;