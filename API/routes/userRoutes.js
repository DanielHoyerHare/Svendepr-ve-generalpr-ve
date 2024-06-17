// importing express module
import express from 'express'

// importing authentcate 
import { authenticate } from '../middlewares/Authenticator.js';

// importing controllers
import { 
    getUsers, 
    getUser, 
    search, 
    createUser, 
    deleteUser, 
    updateUser 
} from '../controllers/userController.js'

// creates new router from express module
const router = express.Router();

// defining post routes
router.get('/', authenticate, getUsers);
router.get('/:id', authenticate, getUser)
router.get('/search', authenticate, search)
router.post('/', authenticate, createUser)
router.delete('/:id', authenticate, deleteUser)
router.put('/:id', authenticate, updateUser)

// exporting router as default
export default router;


