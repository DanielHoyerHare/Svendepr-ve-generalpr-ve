// importing express module
import express from 'express'

// importing controllers
import { 
    getFoods, 
    getFood, 
    search, 
    createFood, 
    deleteFood, 
    updateFood 
} from '../controllers/foodsController.js'
import { authenticate } from '../middlewares/Authenticator.js';

// creates new router from express module
const router = express.Router();

// defining routes
router.get('/', authenticate, getFoods);
router.get('/search/:id', authenticate, getFood)
router.get('/search', authenticate, search)
router.post('/', authenticate, createFood)
router.delete('/:id', authenticate, deleteFood)
router.put('/:id', authenticate, updateFood)

// exports router as default
export default router;


