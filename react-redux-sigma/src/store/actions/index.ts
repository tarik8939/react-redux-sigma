import * as PostActionCreators from './post'
import * as CategoryActionCreators from './category'

export default {
    ...PostActionCreators,
    ...CategoryActionCreators
}
