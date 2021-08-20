public class Status {
    public enum Character {
        HAG,
        Witch,
        Length      //enum의 종류의 길이를 뜻한다. 캐릭터를 추가하려면, 꼭 이 위에 해주길 바란다.
    }
    private Character mch_Character = Character.HAG;
    private float mf_HP = 50f;
    #region define mf_HP setter and getter...
    public float HP {
        get {
            return mf_HP;
        }
        set {
            mf_HP = value;
        }
    }
    #endregion
    private float mf_AttackDamage = 2f;
    #region define mf_AttackDamage setter and getter...
    public float AttackDamage {
        get {
            return mf_AttackDamage;
        }
        set {
            mf_AttackDamage = value;
        }
    }
    #endregion
    private float mf_WalkSpeed = 1f;
    #region define mf_WalkSpeed setter and getter.
    public float WalkSpeed {
        get {
            return mf_WalkSpeed;
        }
        set {
            mf_WalkSpeed = value;
        }
    }
    #endregion
    
    #region define this class constructor.
    public Status() {}
    public Status(Character chCharacter) {
        mch_Character = chCharacter;
    }

    public Status(float fHP) {
        mf_HP = fHP;
    }
    public Status(float fHP, float fAttackDamage) {
        mf_HP = fHP;
        mf_AttackDamage = fAttackDamage;
    }

    public Status(float fHP, float fAttackDamage, float fWalkSpeed) {
        mf_HP = fHP;
        mf_AttackDamage = fAttackDamage;
        mf_WalkSpeed = fWalkSpeed;
    }

    public Status(float fHP, float fAttackDamage, float fWalkSpeed, Character chCharacter) {
        mf_HP = fHP;
        mf_AttackDamage = fAttackDamage;
        mf_WalkSpeed = fWalkSpeed;
        mch_Character = chCharacter;
    }
    #endregion
}
