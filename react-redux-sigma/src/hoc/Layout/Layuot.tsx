import React, {FC} from 'react';
interface Props {
    children: React.ReactNode
}
const Layuot: FC<Props> = (Props) => {
    return (
        <div>
                {Props.children}
        </div>
    );
};

export default Layuot;
