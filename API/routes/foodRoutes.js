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

// creates new router from express module
const router = express.Router();

// defining post routes
router.get('/', getFoods);
router.get('/search/:id', getFood)
router.get('/search', search)
router.post('/', createFood)
router.delete('/:id', deleteFood)
router.put('/:id', updateFood)

// exports router as default
export default router;


